namespace CARMEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USUARIO")]
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            VENTA = new HashSet<VENTA>();
        }

        [Key]
        public int ID_USUARIO { get; set; }

        public int ID_ROL { get; set; }

        public int ID_SUCURSAL { get; set; }

        [Required]
        [StringLength(13)]
        public string CEDULA_USUARIO { get; set; }

        [Required]
        [StringLength(25)]
        public string NOMBRE_USUARIO { get; set; }

        [Required]
        [StringLength(50)]
        public string EMAIL_USUARIO { get; set; }

        [StringLength(1)]
        public string SEXO { get; set; }

        [Required]
        [StringLength(18)]
        public string CONTRACENIA { get; set; }

        [StringLength(25)]
        public string SIS_USUARIO { get; set; }

        public virtual ROL ROL { get; set; }

        public virtual SUCURSAL SUCURSAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VENTA> VENTA { get; set; }
    }
}
