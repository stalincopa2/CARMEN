using CARMEN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaraCoffe.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple= false)]
    public class AuthorizeUser: AuthorizeAttribute
    {
        private USUARIO Usuario;
        private Model1 DB = new Model1();
        private int IdOperacion;

        public AuthorizeUser(int IdOperacion = 0)
        {
            this.IdOperacion = IdOperacion;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            String nombreOperacion = "";
            String nombreModulo = "";
            try
            {
                Usuario = (USUARIO)HttpContext.Current.Session["Usuario"];
                var lstMisOperaciones = from m in DB.ROL_OPERACION
                                        where m.ID_ROL == Usuario.ID_ROL
                                        && m.ID_OPERACION == IdOperacion
                                        select m; 

                if (lstMisOperaciones.ToList().Count() < 1)
                {
                    filterContext.Result = new RedirectResult("~/Error / UnauthorizedOperation");
                }

            }
            catch
            {
                filterContext.Result = new RedirectResult("~/Error / UnauthorizedOperation");
            }
        }

    }
}