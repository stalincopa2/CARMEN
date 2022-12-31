namespace CARMEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BODEGA")]
    public partial class BODEGA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BODEGA()
        {
            BODEGA_PRODUCTO = new HashSet<BODEGA_PRODUCTO>();
        }

        [Key]
        public int ID_BODEGA { get; set; }

        [Required]
        [StringLength(10)]
        public string COD_BODEGA { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE_BODEGA { get; set; }

        [StringLength(100)]
        public string DESCRIPCION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BODEGA_PRODUCTO> BODEGA_PRODUCTO { get; set; }
    }
}
