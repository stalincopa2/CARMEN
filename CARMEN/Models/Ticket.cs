using CARMEN.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CARMEN.Models
{
    public class Ticket
    {
        public string Header { set; get; }
        public string Body { set; get; }
        public string Footer { set; get; }
        public string Printer { set; get; }
        public string DatosCliente { set; get; }
        public int Tipo { set; get; }
    }
}