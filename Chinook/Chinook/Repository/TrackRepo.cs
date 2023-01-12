using Chinook.Models;
using Chinook.Repository;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Repository
{
    public class TrackRepo : ITrackRepo
    {
        private ChinookContext _dbContext;

        public TrackRepo(IDbContextFactory<ChinookContext> dbFactory)
        {
            _dbContext = dbFactory.CreateDbContext();
        }

        public void Create(Track obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Track obj)
        {
            _dbContext.Remove(obj); 
        }

        public Track? Get(long id)
        {
            
               return _dbContext.Tracks.FirstOrDefault(t => t.TrackId == id);
            
        }

        public IEnumerable<Track> ListAll()
        {
            
                return _dbContext.Tracks;
            
        }

        public void Update(Track obj)
        {
            _dbContext.Update(obj);
        }

  
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        IEnumerable<Track> ITrackRepo.ListAllForArtis(long artistId)
        {
            return _dbContext.Tracks.Where(a => a.Album.ArtistId == artistId).Include(a => a.Album);
        }

        public Track? GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
