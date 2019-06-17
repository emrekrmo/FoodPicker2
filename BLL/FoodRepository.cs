using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class FoodRepository : BaseRepository<Food>, IFoodRepository
    {
        private readonly ApplicationDbContext _db;
        public FoodRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public Food RandomFood()
        {
            List<Food> foodList = _db.Foods.ToList();
            Random rnd = new Random();
            Food food = foodList.ElementAt(rnd.Next(foodList.Count()));
            return food;
        }
        //
        public Food HealtyRandomFood()
        {
            List<Food> healthyFood = _db.Foods.Where(x => x.IsHealty == true).ToList();
            Random rnd = new Random();
            Food food = healthyFood.ElementAt(rnd.Next(healthyFood.Count()));
            return food;
        }

        //public Food AllRandomFood(List<Food> foodList)
        //{
        //    Random rnd = new Random();
        //    Food food = foodList.ElementAt(rnd.Next(foodList.Count()));
        //    return food;
        //    //return foodList.OrderBy(x => rnd.Next()).Take(1).ToList();
        //}

        //public Food HealtyRandomFood(List<Food> foodList)
        //{
        //    Random rnd = new Random();
        //    Food food = foodList.ElementAt(rnd.Next(foodList.Count()));
        //    return food;
        //}

        //public Food ListRandomFood(List<Food> foodList)
        //{
        //    Random rnd = new Random();
        //    Food food = foodList.ElementAt(rnd.Next(foodList.Count()));
        //    return food;
        //}
    }
}
