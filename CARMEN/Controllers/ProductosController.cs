using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SaraCoffe.Filters;
using CARMEN.Models;
using CARMEN.Dtos;
using System.IO;
using SaraCoffe.Service;

namespace SaraCoffe.Controllers
{
    public class ProductosController : Controller
    {
        private Model1 db = new Model1();

        // GET: Productos
        public ActionResult Index()
        {
            // var pRODUCTO = db.PRODUCTO.Include(p => p.CATEGORIA);
            var pRODUCTO = db.PRODUCTO;
            return View(pRODUCTO.ToList());
        }


        //GET: Productos/ProductosByCategoria/5
        public JsonResult ProductosByCategoria(int ID_CATEGORIA)
        {
            List<ProductoDto> prSerialized = db.PRODUCTO
                .Where(p => p.ID_CATEGORIA == ID_CATEGORIA)
                .Select(p => new ProductoDto {
                    ID_CATEGORIA = p.ID_CATEGORIA?? default(int),
                    ID_PRODUCTO = p.ID_PRODUCTO ,
                    PRECIO = p.PRECIO,
                    NOMBRE_PRODUCTO = p.NOMBRE_PRODUCTO,
                    COD_PRODUCTO= p.COD_PRODUCTO,
                    FOTO_PRODUCTO = p.FOTO_PRODUCTO
                }).ToList(); 
                      
            if (prSerialized.Any())
            {
                return Json(prSerialized, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet); 
            }
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        //[AuthorizeUser(IdOperacion:1)]
        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA, "ID_CATEGORIA", "NOMBRE");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRODUCTO,ID_CATEGORIA,COD_PRODUCTO,NOMBRE_PRODUCTO,COSTO,PRECIO,FOTO_PRODUCTO")] PRODUCTO pRODUCTO)
        {

            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    PictureService pService = new PictureService();
                    var File = Request.Files[0];
                    pRODUCTO.FOTO_PRODUCTO = pService.Insert(File, Server);
                }
                else
                {
                    pRODUCTO.FOTO_PRODUCTO = "NA";
                }
                db.PRODUCTO.Add(pRODUCTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA, "ID_CATEGORIA", "NOMBRE", pRODUCTO.ID_CATEGORIA);
            return View(pRODUCTO);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA, "ID_CATEGORIA", "NOMBRE", pRODUCTO.ID_CATEGORIA);
            return View(pRODUCTO);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRODUCTO,ID_CATEGORIA,COD_PRODUCTO,NOMBRE_PRODUCTO,COSTO,PRECIO,FOTO_PRODUCTO")] PRODUCTO pRODUCTO)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    PictureService pService = new PictureService();
                    var File = Request.Files[0];
                    pRODUCTO.FOTO_PRODUCTO = pService.Edit(File, Server, pRODUCTO.FOTO_PRODUCTO);
                }

                db.Entry(pRODUCTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA, "ID_CATEGORIA", "NOMBRE", pRODUCTO.ID_CATEGORIA);
            return View(pRODUCTO);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            db.PRODUCTO.Remove(pRODUCTO);
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
