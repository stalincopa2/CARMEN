using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CARMEN.DTOs;
using CARMEN.Models;

namespace SaraCoffe.Controllers
{
    public class ObservasionesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Observasiones
        public ActionResult Index()
        {
            return View(db.OBSERVACION.ToList());
        }

        public JsonResult GetObservaciones()
        {
            List<ObservacionDto> ObsSerialized = db.OBSERVACION
                .Select(p => new ObservacionDto()
                {
                    ID_OBSERVACION = p.ID_OBSERVACION,
                    DET_OBSER = p.DET_OBSER
                }).ToList();

                        if (ObsSerialized.Any())
                        {
                            return Json(ObsSerialized, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(false, JsonRequestBehavior.AllowGet);
                        }
        }

        // GET: Observasiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBSERVACION oBSERVACION = db.OBSERVACION.Find(id);
            if (oBSERVACION == null)
            {
                return HttpNotFound();
            }
            return View(oBSERVACION);
        }

        // GET: Observasiones/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Observasiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult CreateAjax(ObservacionDto oObservcacion)
        {
            String request = "Failed";
            OBSERVACION oBSERVACION = new OBSERVACION();
            var repeat = db.OBSERVACION.Where(o => o.DET_OBSER == oObservcacion.DET_OBSER);

            if (repeat.Any())
            {
                request = "Repeat";
                return Json(request, JsonRequestBehavior.AllowGet);
            }

            if (ModelState.IsValid)
            {
                oBSERVACION.DET_OBSER = oObservcacion.DET_OBSER; 
                db.OBSERVACION.Add(oBSERVACION);
                db.SaveChanges();

                request = "Succes";
                return Json(request, JsonRequestBehavior.AllowGet);
            }

            return Json(request, JsonRequestBehavior.AllowGet);
        }  


        // POST: Observasiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_OBSERVACION,DET_OBSER")] OBSERVACION oBSERVACION)
        {
            if (ModelState.IsValid)
            {
                db.OBSERVACION.Add(oBSERVACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oBSERVACION);
        }

        // GET: Observasiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBSERVACION oBSERVACION = db.OBSERVACION.Find(id);
            if (oBSERVACION == null)
            {
                return HttpNotFound();
            }
            return View(oBSERVACION);
        }

        // POST: Observasiones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_OBSERVACION,DET_OBSER")] OBSERVACION oBSERVACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oBSERVACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oBSERVACION);
        }

        // GET: Observasiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBSERVACION oBSERVACION = db.OBSERVACION.Find(id);
            if (oBSERVACION == null)
            {
                return HttpNotFound();
            }
            return View(oBSERVACION);
        }

        // POST: Observasiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OBSERVACION oBSERVACION = db.OBSERVACION.Find(id);
            db.OBSERVACION.Remove(oBSERVACION);
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
