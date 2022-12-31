namespace CARMEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OPERACION")]
    public partial class OPERACION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OPERACION()
        {
            ROL_OPERACION = new HashSet<ROL_OPERACION>();
        }

        [Key]
        public int ID_OPERACION { get; set; }

        public int? ID_MODULO { get; set; }

        [Required]
        [StringLength(25)]
        public string NOMBRE_OPERACION { get; set; }

        public virtual MODULO MODULO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROL_OPERACION> ROL_OPERACION { get; set; }
    }
}
