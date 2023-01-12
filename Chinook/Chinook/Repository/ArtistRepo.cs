using Chinook.Models;
using Chinook.Repository;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Repository
{
    public class ArtistRepo : IArtistRepo
    {
        private ChinookContext _dbContext;

        public ArtistRepo(IDbContextFactory<ChinookContext> dbFactory)
        {
            _dbContext = dbFactory.CreateDbContext();
        }

        public void Create(Artist obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Artist obj)
        {
            throw new NotImplementedException();
        }

        public Artist? Get(long id)
        {

            return _dbContext.Artists.FirstOrDefault(a => a.ArtistId == id);


        }

        public Artist? GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public  IEnumerable<Artist> ListAll()
        {

            return  _dbContext.Artists;

        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public IEnumerable<Artist> SearchByName(string str)
        {
            return _dbContext.Artists.Where(a => a.Name.ToLower().StartsWith(str.ToLower()));
        }

        public void Update(Artist obj)
        {
            throw new NotImplementedException();
        }
    }
}
