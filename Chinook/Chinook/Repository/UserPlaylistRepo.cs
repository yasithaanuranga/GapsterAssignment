using Chinook.Models;
using Chinook.Repository;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Repository
{
    public class UserPlaylistRepo : IUserPlaylistRepo
    {
        private ChinookContext _dbContext;

        public UserPlaylistRepo(IDbContextFactory<ChinookContext> dbFactory)
        {
            _dbContext = dbFactory.CreateDbContext();
        }
       
        public void Create(UserPlaylist obj)
        {
            _dbContext.Add<UserPlaylist>(obj);  
        }

        public void Delete(UserPlaylist obj)
        {
            throw new NotImplementedException();
        }

        public UserPlaylist? Get(long id)
        {
            throw new NotImplementedException();
        }

        public UserPlaylist? GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserPlaylist> ListAll()
        {
           return _dbContext.UserPlaylists;
        }

        public void Save()
        {
           _dbContext.SaveChanges();
        }

        public void Update(UserPlaylist obj)
        {
            throw new NotImplementedException();
        }
    }
}
