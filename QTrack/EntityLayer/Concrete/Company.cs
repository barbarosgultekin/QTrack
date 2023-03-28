using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Company
    {
        [Key]
        public int COMPANYID { get; set; }
        public string CNAME { get; set; }
        public string CADDRESS { get; set; }
        public string CPHONE { get; set; }
        public string CPERSON { get; set; }
        public string CDOMAIN { get; set; }       
        public bool CSTATUS { get; set; }
        public string COUNTRY { get; set; }
        public string COTHER { get; set; }
        public virtual ICollection<QR> QRs { get; set; }

    }
}
