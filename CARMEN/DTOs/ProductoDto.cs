using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CARMEN.Models;
namespace CARMEN.Dtos
{
    public class ProductoDto
    {
      
        public ProductoDto()
        {
            BODEGA_PRODUCTO = new HashSet<BODEGA_PRODUCTO>();
            EXISTENCIA = new HashSet<EXISTENCIA>();
        }


        public int ID_PRODUCTO { get; set; }

        public int ID_CATEGORIA { get; set; }

        public string COD_PRODUCTO { get; set; }


        public string NOMBRE_PRODUCTO { get; set; }

        public decimal COSTO { get; set; }

        public decimal PRECIO { get; set; }

       // public int IMPUESTO_PROD { get; set; }


        public string FOTO_PRODUCTO { get; set; }



        public virtual ICollection<BODEGA_PRODUCTO> BODEGA_PRODUCTO { get; set; }


        public virtual CATEGORIA CATEGORIA { get; set; }


        public virtual ICollection<EXISTENCIA> EXISTENCIA { get; set; }      
    }
}