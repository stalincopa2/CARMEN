namespace CARMEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EXISTENCIA")]
    public partial class EXISTENCIA
    {
        [Key]
        public int ID_EXISTENCIA { get; set; }

        public int ID_PRODUCTO { get; set; }

        public int STOCK { get; set; }

        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}
