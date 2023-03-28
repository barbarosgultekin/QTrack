using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class QR
    {
        [Key]
        public int QRID { get; set; }
        public Nullable<int> COMPANYID { get; set; }
        public Nullable<int> PRODUCTID { get; set; }
        public string QRCODE { get; set; }
        public bool QRSTATUS { get; set; }
        public string OTHER { get; set; }
        public Nullable<System.DateTime> FACTORYDATE { get; set; }
        public Nullable<System.DateTime> FILLDATE { get; set; }
        public Nullable<System.DateTime> REFILLDATE { get; set; }
        public Nullable<System.DateTime> EXPDATE { get; set; }

        public virtual Company Company { get; set; }
        public virtual Product Product { get; set; }       
        public virtual ICollection<QRHistory> QRHistories { get; set; }
    }
}
