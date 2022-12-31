namespace CARMEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VENTA")]
    public partial class VENTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VENTA()
        {
            DET_PAGO = new HashSet<DET_PAGO>();
            DETALLE_VENTA = new HashSet<DETALLE_VENTA>();
        }

        [Key]
        public int ID_VENTA { get; set; }

        public int ID_USUARIO { get; set; }

        public int ID_ESTVENTA { get; set; }

        public int ID_CLIENTE { get; set; }

        public int? ID_MESA { get; set; }

        [Required]
        [StringLength(32)]
        public string COD_VENTA { get; set; }

        public DateTime FECHA_VENTA { get; set; }

        public decimal TOTAL { get; set; }

        [StringLength(25)]
        public string NRO_FACTURA { get; set; }

        [StringLength(50)]
        public string CLAVE_ACCESO { get; set; }

        public int? NRO_PEDIDO { get; set; }

        public virtual CLIENTE CLIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DET_PAGO> DET_PAGO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_VENTA> DETALLE_VENTA { get; set; }

        public virtual ESTADO_VENTA ESTADO_VENTA { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
