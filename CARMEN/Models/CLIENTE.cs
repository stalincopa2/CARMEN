namespace CARMEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLIENTE")]
    public partial class CLIENTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENTE()
        {
            VENTA = new HashSet<VENTA>();
        }

        [Key]
        public int ID_CLIENTE { get; set; }

        [Required]
        [StringLength(100)]
        public string NOMBRE_CLIENTE { get; set; }

        [Required]
        [StringLength(13)]
        public string RUC_CLIENTE { get; set; }

        [StringLength(50)]
        public string EMAIL_CLIENTE { get; set; }

        [StringLength(11)]
        public string TELEFONO_CLIENTE { get; set; }

        [StringLength(100)]
        public string DIRECCION_CLIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VENTA> VENTA { get; set; }
    }
}
