using SurveyBasket.Api.Models;

namespace SurveyBasket.Api.Services;

public class PollService : IPollService
{
    private static readonly List<Poll> _polls = [ 
       new Poll{
            Id= 1,
            Title = "poll 1",
            Description="my first poll"
        },
       new Poll{
            Id= 2,
            Title = "poll 2",
            Description="my second poll"
        }
       ];
    public IEnumerable<Poll> GetAll()
    {
        return _polls;
    }
    public Poll? Get(int id)
    {
        return _polls.FirstOrDefault(p => p.Id == id);
    }
}
