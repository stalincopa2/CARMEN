using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CARMEN.DTOs
{
    public class AreaImpresionDto
    {
        public int ID_AREA { get; set; }
        public int ID_SUCURSAL { get; set; }
        public string NOMBRE_AREA { get; set; }
        public string IP { get; set; }
    }
}