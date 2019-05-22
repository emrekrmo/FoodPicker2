using Entity;
using System.Data.Entity;

namespace DAL
{
    public class FoodContext : DbContext
    {
        public FoodContext() : base("FoodPickerCon") { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }        
    }
}
