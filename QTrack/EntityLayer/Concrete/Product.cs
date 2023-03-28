using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int PRODUCTID { get; set; }
        public int PTYPEID { get; set; }
        public string PNAME { get; set; }
        public string SERIAL { get; set; }
        public string POTHER { get; set; }
        public string PCAPACITY { get; set; }
        public string LOCATION { get; set; }
        public bool PSTATUS { get; set; }
        public Nullable<System.DateTime> MANUDATE { get; set; }
        public virtual ICollection<QR> QRs { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}
