namespace CARMEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ROL_OPERACION
    {
        [Key]
        public int ID_ROPE { get; set; }

        public int? ID_ROL { get; set; }

        public int? ID_OPERACION { get; set; }

        public virtual OPERACION OPERACION { get; set; }

        public virtual ROL ROL { get; set; }
    }
}
