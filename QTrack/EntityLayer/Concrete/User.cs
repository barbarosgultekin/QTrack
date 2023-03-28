﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int USERID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string USERTYPE { get; set; }
        public bool USERSTATUS { get; set; }
    }
}
