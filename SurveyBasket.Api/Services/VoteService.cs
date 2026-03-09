using Mapster;
using SurveyBasket.Api.Contracts.Votes;
using SurveyBasket.Api.Errors;

namespace SurveyBasket.Api.Services;

public class VoteService(ApplicationDbContext context) : IVoteService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result> AddAsync(int pollId, string userId, VoteRequest request, CancellationToken cancellationToken = default)
    {
        var hasVote = await _context.Votes.AnyAsync(c => c.PollId == pollId && c.UserId == userId, cancellationToken);

        if (hasVote)
            return Result.Failure(VoteErrors.DuplicatedVote);

        var pollIsExists = await _context.Polls.AnyAsync(c => c.Id == pollId && c.IsPublished && c.StartsAt <= DateOnly.FromDateTime(DateTime.UtcNow) && c.EndsAt >= DateOnly.FromDateTime(DateTime.UtcNow), cancellationToken);

        if (!pollIsExists)
            return Result.Failure(PollErrors.PollNotFound);

        var availableQuestion = await _context.Questions
           .Where(c => c.PollId == pollId && c.IsActive)
           .Select(x => x.Id)
           .ToListAsync(cancellationToken);

        if (!request.Answers.Select(c => c.QuestionId).SequenceEqual(availableQuestion))
            return Result.Failure(VoteErrors.InvalidQuestions);

        var vote = new Vote
        {
            PollId = pollId,
            UserId = userId,
            VoteAnswers = request.Answers.Adapt<IEnumerable<VoteAnswer>>().ToList()
        };

        await _context.AddAsync(vote, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
