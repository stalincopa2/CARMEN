namespace CARMEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SUCURSAL")]
    public partial class SUCURSAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUCURSAL()
        {
            AREA_IMPRESION = new HashSet<AREA_IMPRESION>();
            USUARIO = new HashSet<USUARIO>();
        }

        [Key]
        public int ID_SUCURSAL { get; set; }

        [Required]
        [StringLength(13)]
        public string RUC { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }

        [StringLength(50)]
        public string DIRECCION { get; set; }

        [StringLength(10)]
        public string TELEFONO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AREA_IMPRESION> AREA_IMPRESION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO> USUARIO { get; set; }
    }
}
