namespace CARMEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SALON")]
    public partial class SALON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SALON()
        {
            MESA = new HashSet<MESA>();
        }

        [Key]
        public short ID_SALON { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE_SALON { get; set; }

        [StringLength(250)]
        public string DESCRIPCION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MESA> MESA { get; set; }
    }
}
