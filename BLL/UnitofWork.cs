
using BLL.Repos;

using DAL;
using Entity;
using System;

namespace BLL
{
    public class UnitOfWork : IDisposable
    {
        FoodContext _db = new FoodContext();
    
        public BaseRepository<Food, int> foodRep;
 

        public UnitOfWork()
        {
            foodRep = new BaseRepository<Food, int>(_db);
         
        }

        public void Complete()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
          
        }
    }
}
