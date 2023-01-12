using Chinook.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Repository
{
    public class PlayListRepo : IplayListRepo
    {
        private ChinookContext _dbContext;

        public PlayListRepo(IDbContextFactory<ChinookContext> dbFactory)
        {
            _dbContext = dbFactory.CreateDbContext();
        }
        public void Create(Playlist obj)
        {
            _dbContext.Add(obj);
          
        }

        public void Delete(Playlist obj)
        {
            _dbContext.Remove(obj);
        }


        public Playlist? Get(long id)
        {
          return  _dbContext.Playlists.Where(p=>p.PlaylistId==id).FirstOrDefault();
        }

        public  IEnumerable<Playlist> ListAll()
        {
            return  _dbContext.Playlists.Include(c => c.UserPlaylists);
        }

        public  IEnumerable<Playlist> ListAllForUserId(string userId)
        {
            return  _dbContext.Playlists.Include(c => c.UserPlaylists).Where(p => p.UserPlaylists.Any(s => s.UserId == userId));
        }

        public void Update(Playlist obj)
        {
            _dbContext.Update(obj);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public Chinook.ClientModels.Playlist GetWithOtherDataForPlaylistId(long PlaylistId,string CurrentUserId)
        {
            return _dbContext.Playlists
            .Include(a => a.Tracks).ThenInclude(a => a.Album).ThenInclude(a => a.Artist)
            .Where(p => p.PlaylistId == PlaylistId)
            .Select(p => new ClientModels.Playlist()
            {
                Name = p.Name,
                Tracks = p.Tracks.Select(t => new ClientModels.PlaylistTrack()
                {
                    AlbumTitle = t.Album.Title,
                    ArtistName = t.Album.Artist.Name,
                    TrackId = t.TrackId,
                    TrackName = t.Name,
                    IsFavorite = t.Playlists.Where(p => p.UserPlaylists.Any(up => up.UserId == CurrentUserId && up.Playlist.Name == "Favorites")).Any()
                }).ToList()
            })
            .FirstOrDefault();
        }

        public Playlist? GetByName(string name)
        {
           return _dbContext.Playlists.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
