using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CARMEN.DTOs
{
    public class ClienteDto
    {

        public int ID_CLIENTE { get; set; }

        public string NOMBRE_CLIENTE { get; set; }

        public string RUC_CLIENTE { get; set; }


        public string EMAIL_CLIENTE { get; set; }

 
        public string TELEFONO_CLIENTE { get; set; }


        public string DIRECCION_CLIENTE { get; set; }
    }
}