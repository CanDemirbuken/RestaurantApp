using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMVC.Core.Entitites
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
