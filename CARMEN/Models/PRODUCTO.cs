namespace CARMEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCTO")]
    public partial class PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTO()
        {
            BODEGA_PRODUCTO = new HashSet<BODEGA_PRODUCTO>();
            DETALLE_VENTA = new HashSet<DETALLE_VENTA>();
            EXISTENCIA = new HashSet<EXISTENCIA>();
        }

        [Key]
        public int ID_PRODUCTO { get; set; }

        public int? ID_CATEGORIA { get; set; }

        [Required]
        [StringLength(10)]
        public string COD_PRODUCTO { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE_PRODUCTO { get; set; }

        public decimal COSTO { get; set; }

        public decimal PRECIO { get; set; }

        [StringLength(50)]
        public string FOTO_PRODUCTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BODEGA_PRODUCTO> BODEGA_PRODUCTO { get; set; }

        public virtual CATEGORIA CATEGORIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_VENTA> DETALLE_VENTA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXISTENCIA> EXISTENCIA { get; set; }
    }
}
