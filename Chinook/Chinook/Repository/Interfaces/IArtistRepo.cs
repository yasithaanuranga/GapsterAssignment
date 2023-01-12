using Chinook.Models;

namespace Chinook.Repository
{
    public interface IArtistRepo : IBaseRepo<Artist>
    {
        IEnumerable<Artist> SearchByName(string str);
    }
}
