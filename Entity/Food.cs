using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Entity
{
    public class Food : BaseEntity
    {
        public string FoodName { get; set; }
        public decimal Price { get; set; }
        public bool IsHealty { get; set; }
        public FoodType FoodType { get; set; }
        public string ImageURL { get; set; }

        public int RestaurantId { get; set; }
        public string  ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
    public enum FoodType
    {
        Hamburger,
        Pizza,
        Döner,
        Kebap,
        Balık,
        Pasta,
        Kumpir,
        Et,
        Kahvaltı,
        Cafe,
        Çin,
        Japon,
        Börek,
        Tavuk
    }
}
