using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class QRHistory
    {
        [Key]
        public int REFID { get; set; }
        public int QRID { get; set; }
        public string OPERATION { get; set; }
        public Nullable<System.DateTime> OPERATIONDATE { get; set; }
        public virtual QR QR { get; set; }
    }
}
