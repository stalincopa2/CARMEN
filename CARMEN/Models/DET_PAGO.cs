namespace CARMEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DET_PAGO
    {
        [Key]
        public int ID_DETPAGO { get; set; }

        public int ID_VENTA { get; set; }

        public int ID_METODO { get; set; }

        public decimal MONTO { get; set; }

        public virtual METODO_PAGO METODO_PAGO { get; set; }

        public virtual VENTA VENTA { get; set; }
    }
}
