using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IFoodRepository : IRepository<Food>
    {
        Food RandomFood();
        Food HealtyRandomFood();
        //string SelectedRandomFood(List<Food> selectedFoodList);
        //Food AllRandomFood(List<Food> foodList);
        //Food RandomFood(List<Food> foodList);
        //Food AllRandomFood(List<Food> foodList);
        //Food HealtyRandomFood(List<Food> foodList);
        //Food ListRandomFood(List<Food> foodList);
    }
}
