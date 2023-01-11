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
    public class Det_PagosController : Controller
    {
        private Model1 db = new Model1();

        // GET: DET_PAGO
        public ActionResult Index()
        {
            var dET_PAGO = db.DET_PAGO.Include(d => d.METODO_PAGO).Include(d => d.VENTA);
            return View(dET_PAGO.ToList());
        }

        //GetDetPagosByVentas
        public ActionResult GetDetPagosByVentas(int? id)
        {
            if (id == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet); 
            }
            List<DetPagoDto> dpSerlialized = db.DET_PAGO
                        .Where(p => p.ID_VENTA== id)
                        .Select(p => new  DetPagoDto()
                        {
                            ID_DETPAGO = p.ID_DETPAGO,
                            ID_VENTA= p.ID_VENTA,
                            ID_METODO = p.ID_METODO,
                            MONTO= p.MONTO,
                        }).ToList();

            if (dpSerlialized.Any())
            {
                return Json(dpSerlialized, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: DET_PAGO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DET_PAGO dET_PAGO = db.DET_PAGO.Find(id);
            if (dET_PAGO == null)
            {
                return HttpNotFound();
            }
            return View(dET_PAGO);
        }

        // GET: DET_PAGO/Create
        public ActionResult Create(VENTA venta)
        {
            
            ViewBag.ID_METODO = new SelectList(db.METODO_PAGO, "ID_METODO", "NOMBRE");
            ViewBag.ID_VENTA = new SelectList(db.VENTA, "ID_VENTA", "COD_VENTA");
            return View();
        }
        // POST: DET_PAGO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDetPagos(VENTA vENTA)
        {
            VENTA vAux = db.VENTA.Find(vENTA.ID_VENTA);
            if (vAux != null)
            {
                foreach (var item in vENTA.DET_PAGO)
                {
                    item.ID_VENTA = vENTA.ID_VENTA; 
                    db.DET_PAGO.Add(item); 
                }
                vAux.ID_ESTVENTA = vENTA.ID_VENTA;
                vAux.ID_ESTVENTA = vENTA.ID_ESTVENTA; 

                db.Entry(vAux).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Success","Ventas", new { id = vENTA.ID_VENTA, TipoRegistro = 2 });
               
            }
            return HttpNotFound();
        }


        // POST: DET_PAGO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "ID_DETPAGO,ID_VENTA,ID_METODO,MONTO")] DET_PAGO dET_PAGO)
            {
                if (ModelState.IsValid)
                {
                    db.DET_PAGO.Add(dET_PAGO);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ID_METODO = new SelectList(db.METODO_PAGO, "ID_METODO", "NOMBRE", dET_PAGO.ID_METODO);
                ViewBag.ID_VENTA = new SelectList(db.VENTA, "ID_VENTA", "COD_VENTA", dET_PAGO.ID_VENTA);
                return View(dET_PAGO);
            }

            // GET: DET_PAGO/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                DET_PAGO dET_PAGO = db.DET_PAGO.Find(id);
                if (dET_PAGO == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ID_METODO = new SelectList(db.METODO_PAGO, "ID_METODO", "NOMBRE", dET_PAGO.ID_METODO);
                ViewBag.ID_VENTA = new SelectList(db.VENTA, "ID_VENTA", "COD_VENTA", dET_PAGO.ID_VENTA);
                return View(dET_PAGO);
            }

            // POST: DET_PAGO/Edit/5
            // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
            // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "ID_DETPAGO,ID_VENTA,ID_METODO,MONTO")] DET_PAGO dET_PAGO)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(dET_PAGO).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ID_METODO = new SelectList(db.METODO_PAGO, "ID_METODO", "NOMBRE", dET_PAGO.ID_METODO);
                ViewBag.ID_VENTA = new SelectList(db.VENTA, "ID_VENTA", "COD_VENTA", dET_PAGO.ID_VENTA);
                return View(dET_PAGO);
            }

            // GET: DET_PAGO/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                DET_PAGO dET_PAGO = db.DET_PAGO.Find(id);
                if (dET_PAGO == null)
                {
                    return HttpNotFound();
                }
                return View(dET_PAGO);
            }

            // POST: DET_PAGO/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                DET_PAGO dET_PAGO = db.DET_PAGO.Find(id);
                db.DET_PAGO.Remove(dET_PAGO);
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
