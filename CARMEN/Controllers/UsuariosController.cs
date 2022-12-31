using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CARMEN.Models;

namespace SaraCoffe.Controllers
{
    public class UsuariosController : Controller
    {
        private Model1 db = new Model1();

        // GET: USUARIOs
        public ActionResult Index()
        {
            var uSUARIO = db.USUARIO.Include(u => u.ROL).Include(u => u.SUCURSAL);
            return View(uSUARIO.ToList());
        }

        // GET: USUARIOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // GET: USUARIOs/Create
        public ActionResult Create()
        {
            ViewBag.ID_ROL = new SelectList(db.ROL, "ID_ROL", "NOMBRE_ROL");
            ViewBag.ID_SUCURSAL = new SelectList(db.SUCURSAL, "ID_SUCURSAL", "RUC");
            return View();
        }

        // POST: USUARIOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_USUARIO,ID_ROL,ID_SUCURSAL,CEDULA_USUARIO,NOMBRE_USUARIO,EMAIL_USUARIO,SEXO,CONTRACENIA,SIS_USUARIO")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.USUARIO.Add(uSUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ROL = new SelectList(db.ROL, "ID_ROL", "NOMBRE_ROL", uSUARIO.ID_ROL);
            ViewBag.ID_SUCURSAL = new SelectList(db.SUCURSAL, "ID_SUCURSAL", "RUC", uSUARIO.ID_SUCURSAL);
            return View(uSUARIO);
        }

        // GET: USUARIOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ROL = new SelectList(db.ROL, "ID_ROL", "NOMBRE_ROL", uSUARIO.ID_ROL);
            ViewBag.ID_SUCURSAL = new SelectList(db.SUCURSAL, "ID_SUCURSAL", "RUC", uSUARIO.ID_SUCURSAL);
            return View(uSUARIO);
        }

        // POST: USUARIOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_USUARIO,ID_ROL,ID_SUCURSAL,CEDULA_USUARIO,NOMBRE_USUARIO,EMAIL_USUARIO,SEXO,CONTRACENIA,SIS_USUARIO")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ROL = new SelectList(db.ROL, "ID_ROL", "NOMBRE_ROL", uSUARIO.ID_ROL);
            ViewBag.ID_SUCURSAL = new SelectList(db.SUCURSAL, "ID_SUCURSAL", "RUC", uSUARIO.ID_SUCURSAL);
            return View(uSUARIO);
        }

        // GET: USUARIOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: USUARIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USUARIO uSUARIO = db.USUARIO.Find(id);
            db.USUARIO.Remove(uSUARIO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
