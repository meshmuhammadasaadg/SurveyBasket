
namespace SurveyBasket.Api.Services;

public class PollService(ApplicationDbContext context) : IPollService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<Poll>> GetAllAsync(CancellationToken cancellationToken = default) =>
         await _context.Polls.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<Poll?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
         await _context.Polls.FindAsync(id, cancellationToken);

    public async Task<Poll> AddAsync(Poll poll, CancellationToken cancellationToken = default)
    {
        await _context.AddAsync(poll, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return poll;
    }

    public async Task<bool> UpdateAsync(int id, Poll poll, CancellationToken cancellationToken = default)
    {
        var oldPoll = await GetByIdAsync(id, cancellationToken);

        if (oldPoll is null)
            return false;

        oldPoll.Title = poll.Title;
        oldPoll.Summary = poll.Summary;
        oldPoll.StartsAt = poll.StartsAt;
        oldPoll.EndsAt = poll.EndsAt;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var poll = await GetByIdAsync(id, cancellationToken);

        if (poll is null)
            return false;

        _context.Remove(poll);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> TogglePublishAsync(int id, CancellationToken cancellationToken = default)
    {
        var poll = await GetByIdAsync(id, cancellationToken);

        if (poll is null)
            return false;

        poll.IsPublished = !poll.IsPublished;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}

