using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Restaurant : BaseEntity
    {
        public string RestaurantName { get; set; }
        public string ApplicationUserId { get; set; }

        public  ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
    }
}
