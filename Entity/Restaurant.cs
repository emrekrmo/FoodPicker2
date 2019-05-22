using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Restaurant : BaseEntity
    {
        public string RestaurantName { get; set; }

        public int UserId { get; set; }

        public virtual List<Food> Foods { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }    
}
