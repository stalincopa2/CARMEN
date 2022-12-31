using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CARMEN.Models
{
    public class Ticket
    {
        public operaciones operaciones { set; get; }
        public String nombreImpresora { get; set; }
        public string serial { get; set; }
            
        public Ticket()
        {
            this.serial = ""; 
        }
    }
}