using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Food : BaseEntity
    {
        public string FoodName { get; set; }
        public decimal Price { get; set; }
        public bool IsHealty { get; set; }
        public FoodType FoodType { get; set; }

        public int RestaurantId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("RestaurantId")]
        public virtual Restaurant Restaurant { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }

    public enum FoodType
    {
        Hamburger,
        Pizza,
        Döner,
        Kebap
    }
}
