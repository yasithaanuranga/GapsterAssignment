using Chinook.Models;

namespace Chinook.Repository
{
    public interface ITrackRepo : IBaseRepo<Track>
    {
        IEnumerable<Track> ListAllForArtis(long artistId);
    }
}
