using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        public FoodRepository foodRep;
        public BaseRepository<Restaurant> restRep;
        public UnitOfWork()
        {
            foodRep = new FoodRepository(db);
            restRep = new BaseRepository<Restaurant>(db);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
