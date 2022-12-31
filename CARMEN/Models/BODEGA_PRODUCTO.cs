namespace CARMEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BODEGA_PRODUCTO
    {
        [Key]
        public int ID_BODE_PRO { get; set; }

        public int ID_BODEGA { get; set; }

        public int ID_PRODUCTO { get; set; }

        public virtual BODEGA BODEGA { get; set; }

        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}
