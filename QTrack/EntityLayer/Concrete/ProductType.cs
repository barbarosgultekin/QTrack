using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProductType
    {
        [Key]
        public int PTYPEID { get; set; }
        public string PTYPE { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
