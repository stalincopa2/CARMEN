using CARMEN.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

namespace CARMEN.DTOs
{
    public class DetPagoDto
    {
        public int ID_DETPAGO { get; set; }

        public int ID_VENTA { get; set; }

        public int ID_METODO { get; set; }

        public decimal MONTO { get; set; }

        //public virtual METODO_PAGO METODO_PAGO { get; set; }

        //public virtual VENTA VENTA { get; set; }
    }
}