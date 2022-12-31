using SaraCoffe.Controllers;
using CARMEN.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace CARMEN.Filters
{
    
    public class VerificaSession:ActionFilterAttribute
    {
        private USUARIO Usuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                Usuario = (USUARIO)HttpContext.Current.Session["Usuario"];
                if (Usuario == null)
                {
                    if (filterContext.Controller is AccesoController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Acceso/Login"); 
                    }
                }
            }
            catch(Exception)
            {
                filterContext.Result = new RedirectResult("~Acceso/Login"); 
            }
            
        }

    }
}