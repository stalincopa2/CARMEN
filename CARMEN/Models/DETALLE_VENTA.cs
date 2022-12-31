namespace CARMEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DETALLE_VENTA
    {
        [Key]
        public int ID_DVENTA { get; set; }

        public int ID_VENTA { get; set; }

        public int ID_PRODUCTO { get; set; }

        public int? ID_OBSERVACION { get; set; }

        public int CANTIDAD { get; set; }

        public decimal PRECIO_UPRODUCT { get; set; }

        public virtual OBSERVACION OBSERVACION { get; set; }

        public virtual PRODUCTO PRODUCTO { get; set; }

        public virtual VENTA VENTA { get; set; }
    }
}
