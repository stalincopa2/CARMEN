using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CARMEN.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<AREA_IMPRESION> AREA_IMPRESION { get; set; }
        public virtual DbSet<BODEGA> BODEGA { get; set; }
        public virtual DbSet<BODEGA_PRODUCTO> BODEGA_PRODUCTO { get; set; }
        public virtual DbSet<CATEGORIA> CATEGORIA { get; set; }
        public virtual DbSet<CLIENTE> CLIENTE { get; set; }
        public virtual DbSet<DET_PAGO> DET_PAGO { get; set; }
        public virtual DbSet<DETALLE_VENTA> DETALLE_VENTA { get; set; }
        public virtual DbSet<ESTADO_VENTA> ESTADO_VENTA { get; set; }
        public virtual DbSet<EXISTENCIA> EXISTENCIA { get; set; }
        public virtual DbSet<MESA> MESA { get; set; }
        public virtual DbSet<METODO_PAGO> METODO_PAGO { get; set; }
        public virtual DbSet<MODULO> MODULO { get; set; }
        public virtual DbSet<OBSERVACION> OBSERVACION { get; set; }
        public virtual DbSet<OPERACION> OPERACION { get; set; }
        public virtual DbSet<PRODUCTO> PRODUCTO { get; set; }
        public virtual DbSet<ROL> ROL { get; set; }
        public virtual DbSet<ROL_OPERACION> ROL_OPERACION { get; set; }
        public virtual DbSet<SALON> SALON { get; set; }
        public virtual DbSet<SUCURSAL> SUCURSAL { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        public virtual DbSet<VENTA> VENTA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AREA_IMPRESION>()
                .Property(e => e.NOMBRE_AREA)
                .IsUnicode(false);

            modelBuilder.Entity<AREA_IMPRESION>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<BODEGA>()
                .Property(e => e.COD_BODEGA)
                .IsUnicode(false);

            modelBuilder.Entity<BODEGA>()
                .Property(e => e.NOMBRE_BODEGA)
                .IsUnicode(false);

            modelBuilder.Entity<BODEGA>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<BODEGA>()
                .HasMany(e => e.BODEGA_PRODUCTO)
                .WithRequired(e => e.BODEGA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CATEGORIA>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORIA>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.NOMBRE_CLIENTE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.RUC_CLIENTE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.EMAIL_CLIENTE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.TELEFONO_CLIENTE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.DIRECCION_CLIENTE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .HasMany(e => e.VENTA)
                .WithRequired(e => e.CLIENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DET_PAGO>()
                .Property(e => e.MONTO)
                .HasPrecision(16, 2);

            modelBuilder.Entity<DETALLE_VENTA>()
                .Property(e => e.PRECIO_UPRODUCT)
                .HasPrecision(16, 2);

            modelBuilder.Entity<ESTADO_VENTA>()
                .Property(e => e.NOMBRE_ESTADOV)
                .IsUnicode(false);

            modelBuilder.Entity<ESTADO_VENTA>()
                .Property(e => e.DESCRIPCION_ESV)
                .IsUnicode(false);

            modelBuilder.Entity<ESTADO_VENTA>()
                .HasMany(e => e.VENTA)
                .WithRequired(e => e.ESTADO_VENTA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MESA>()
                .Property(e => e.COD_MESA)
                .IsUnicode(false);

            modelBuilder.Entity<MESA>()
                .Property(e => e.NOMBRE_MESA)
                .IsUnicode(false);

            modelBuilder.Entity<METODO_PAGO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<METODO_PAGO>()
                .Property(e => e.DETALLE_MPAGO)
                .IsUnicode(false);

            modelBuilder.Entity<METODO_PAGO>()
                .HasMany(e => e.DET_PAGO)
                .WithRequired(e => e.METODO_PAGO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MODULO>()
                .Property(e => e.NOMBRE_MODULO)
                .IsUnicode(false);

            modelBuilder.Entity<OBSERVACION>()
                .Property(e => e.DET_OBSER)
                .IsUnicode(false);

            modelBuilder.Entity<OPERACION>()
                .Property(e => e.NOMBRE_OPERACION)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.COD_PRODUCTO)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.NOMBRE_PRODUCTO)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.COSTO)
                .HasPrecision(16, 2);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.PRECIO)
                .HasPrecision(16, 2);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.FOTO_PRODUCTO)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .HasMany(e => e.BODEGA_PRODUCTO)
                .WithRequired(e => e.PRODUCTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCTO>()
                .HasMany(e => e.DETALLE_VENTA)
                .WithRequired(e => e.PRODUCTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCTO>()
                .HasMany(e => e.EXISTENCIA)
                .WithRequired(e => e.PRODUCTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROL>()
                .Property(e => e.NOMBRE_ROL)
                .IsUnicode(false);

            modelBuilder.Entity<ROL>()
                .HasMany(e => e.USUARIO)
                .WithRequired(e => e.ROL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SALON>()
                .Property(e => e.NOMBRE_SALON)
                .IsUnicode(false);

            modelBuilder.Entity<SALON>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<SALON>()
                .HasMany(e => e.MESA)
                .WithRequired(e => e.SALON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUCURSAL>()
                .Property(e => e.RUC)
                .IsUnicode(false);

            modelBuilder.Entity<SUCURSAL>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<SUCURSAL>()
                .Property(e => e.DIRECCION)
                .IsUnicode(false);

            modelBuilder.Entity<SUCURSAL>()
                .Property(e => e.TELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<SUCURSAL>()
                .HasMany(e => e.USUARIO)
                .WithRequired(e => e.SUCURSAL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.CEDULA_USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.NOMBRE_USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.EMAIL_USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.SEXO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.CONTRACENIA)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.SIS_USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.VENTA)
                .WithRequired(e => e.USUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VENTA>()
                .Property(e => e.COD_VENTA)
                .IsUnicode(false);

            modelBuilder.Entity<VENTA>()
                .Property(e => e.TOTAL)
                .HasPrecision(16, 2);

            modelBuilder.Entity<VENTA>()
                .Property(e => e.NRO_FACTURA)
                .IsUnicode(false);

            modelBuilder.Entity<VENTA>()
                .Property(e => e.CLAVE_ACCESO)
                .IsUnicode(false);

            modelBuilder.Entity<VENTA>()
                .HasMany(e => e.DET_PAGO)
                .WithRequired(e => e.VENTA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VENTA>()
                .HasMany(e => e.DETALLE_VENTA)
                .WithRequired(e => e.VENTA)
                .WillCascadeOnDelete(false);
        }
    }
}
