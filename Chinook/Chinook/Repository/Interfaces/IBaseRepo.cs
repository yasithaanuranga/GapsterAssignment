using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook.Repository
{
    public interface IBaseRepo<TObj>
    {
        public TObj? Get(long id);
        public void Create(TObj obj);
        public void Update(TObj obj);
        public void Delete(TObj obj);
        public void Save();
        public IEnumerable<TObj> ListAll();
        public TObj? GetByName(String name);

    }
}
