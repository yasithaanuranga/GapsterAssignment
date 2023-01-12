using Chinook.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace Chinook.Repository
{
    public class AlbumRepository : IAlbumRepo
    {
        private ChinookContext _dbContext;
      
        public AlbumRepository(IDbContextFactory<ChinookContext> DbFactory)
        {
            _dbContext = DbFactory.CreateDbContext();
        }


        public void Create(Album obj)
        {
            _dbContext.Albums.Add(obj);
           
        }

        public void Delete(Album obj)
        {
            _dbContext.Albums.Remove(obj);

        }

        public Album? Get(long id)
        {
            return _dbContext.Albums.Find(id);
        }

        public Album? GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Album> ListAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Album obj)
        {
            _dbContext.Albums.Update(obj);
         
        }
    }
}
