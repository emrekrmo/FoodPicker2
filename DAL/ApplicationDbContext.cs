using Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
 
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("FoodPickerCon", throwIfV1Schema: false)
        {
        }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
     
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            #region TableSettings

            builder.Entity<Food>()
                .HasKey(x => x.Id);

            builder.Entity<Food>()
                .HasIndex(x => x.Price);

            builder.Entity<Restaurant>()
                .HasKey(x => x.Id);

            #endregion

            #region PropertySettings

            builder.Entity<Food>()
                .Property(x => x.FoodName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<Food>()
                .Property(x => x.Price)
                .IsRequired();

            builder.Entity<Food>()
                .Property(x => x.IsHealty)
                .IsRequired();

            builder.Entity<Food>()
                .Property(x => x.FoodType)
                .IsRequired();

            //Restaurant should be added

            #endregion

            #region Relations


            builder.Entity<Food>() //Food(many) - Restaurant(1)
                .HasRequired(x => x.Restaurant)
                .WithMany(x => x.Foods)
                .HasForeignKey(x => x.RestaurantId);

            //builder.Entity<Food>() //Food(many) - User(1)
            //    .HasRequired(x => x.ApplicationUser)
            //    .WithMany(x => x.Foods)
            //    .HasForeignKey(x => x.ApplicationUserId);

            builder.Entity<ApplicationUser>().HasMany(au => au.Foods)
                .WithOptional(f => f.ApplicationUser)
                .HasForeignKey(x => x.ApplicationUserId);

            builder.Entity<ApplicationUser>()
                .HasMany(au => au.Restaurants)
                .WithOptional(f => f.ApplicationUser)
                .HasForeignKey(x => x.ApplicationUserId);

            //builder.Entity<Restaurant>() //Restaurant(many) - User(1)
            //    .HasRequired(x => x.ApplicationUser)
            //    .WithMany(x => x.Restaurants)
            //    .HasForeignKey(x => x.ApplicationUserId);

            #endregion

            base.OnModelCreating(builder);
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
