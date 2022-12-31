namespace CARMEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MESA")]
    public partial class MESA
    {
        [Key]
        public int ID_MESA { get; set; }

        public short ID_SALON { get; set; }

        [Required]
        [StringLength(10)]
        public string COD_MESA { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE_MESA { get; set; }

        public virtual SALON SALON { get; set; }
    }
}
