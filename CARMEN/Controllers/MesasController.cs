using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CARMEN.Models;

namespace CARMEN.Controllers
{
    public class MesasController : Controller
    {
        private Model1 db = new Model1();

        // GET: Mesas
        public ActionResult Index()
        {
            var mESA = db.MESA.Include(m => m.SALON);
            return View(mESA.ToList());
        }

        // GET: Mesas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MESA mESA = db.MESA.Find(id);
            if (mESA == null)
            {
                return HttpNotFound();
            }
            return View(mESA);
        }

        // GET: Mesas/Create
        public ActionResult Create()
        {
            ViewBag.ID_SALON = new SelectList(db.SALON, "ID_SALON", "NOMBRE_SALON");
            return View();
        }

        // POST: Mesas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_MESA,ID_SALON,COD_MESA,NOMBRE_MESA")] MESA mESA)
        {
            if (ModelState.IsValid)
            {
                db.MESA.Add(mESA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_SALON = new SelectList(db.SALON, "ID_SALON", "NOMBRE_SALON", mESA.ID_SALON);
            return View(mESA);
        }

        // GET: Mesas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MESA mESA = db.MESA.Find(id);
            if (mESA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_SALON = new SelectList(db.SALON, "ID_SALON", "NOMBRE_SALON", mESA.ID_SALON);
            return View(mESA);
        }

        // POST: Mesas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MESA,ID_SALON,COD_MESA,NOMBRE_MESA")] MESA mESA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mESA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_SALON = new SelectList(db.SALON, "ID_SALON", "NOMBRE_SALON", mESA.ID_SALON);
            return View(mESA);
        }

        // GET: Mesas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MESA mESA = db.MESA.Find(id);
            if (mESA == null)
            {
                return HttpNotFound();
            }
            return View(mESA);
        }

        // POST: Mesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MESA mESA = db.MESA.Find(id);
            db.MESA.Remove(mESA);
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
