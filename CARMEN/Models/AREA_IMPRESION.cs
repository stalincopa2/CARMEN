namespace CARMEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AREA_IMPRESION
    {
        [Key]
        public int ID_AREA { get; set; }

        public int? ID_SUCURSAL { get; set; }

        [StringLength(25)]
        public string NOMBRE_AREA { get; set; }

        [StringLength(25)]
        public string IP { get; set; }

        
        public int TIPO { get; set; }

        public virtual SUCURSAL SUCURSAL { get; set; }
    }
}
