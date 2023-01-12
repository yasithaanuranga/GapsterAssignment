using Chinook.Models;
using System.Numerics;

namespace Chinook.Repository
{
    public interface IplayListRepo : IBaseRepo<Playlist>
    {
        IEnumerable<Playlist> ListAllForUserId(string userId);
        Chinook.ClientModels.Playlist GetWithOtherDataForPlaylistId(long PlaylistId, string CurrentUserId);

       
    }
}
