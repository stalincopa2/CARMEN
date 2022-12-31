using CARMEN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaraCoffe.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string User, string Password)
        {
            using (Model1 db = new Model1())
            {
                var oUser = (from u in db.USUARIO
                             where u.SIS_USUARIO == User.Trim() && u.CONTRACENIA == Password
                             select u).FirstOrDefault();
                if (oUser == null) {
                    return View();
                }                 
                Session["Usuario"] = oUser;
            }

            return RedirectToAction("Index", "Home");
        }
    }
}