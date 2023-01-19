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
    public class VentasController : Controller
    {
        private Model1 db = new Model1();

        // GET: Ventas
        public ActionResult Index(int eVent = 1, int pg = 1)
        {
            const int pageSize = 10;
            if (pg < 1)
                pg = 1;
            if (eVent < 1)
                eVent = 1;

            var data1 =db.VENTA.Where(v => v.ID_ESTVENTA == eVent).Count();

            var pagina = new PAGINA(data1, pg, pageSize);

            ViewBag.pagina = pagina;

            var vENTA = db.VENTA.Where(v => v.ID_ESTVENTA == eVent)
                .OrderByDescending(v => v.ID_VENTA)
                .Skip((pg - 1) * pageSize)
                .Take(pagina.PageSize)
                .Include(v => v.ESTADO_VENTA)
                .Include(v => v.USUARIO);
            
            //var vENTA = db.VENTA.Include(v => v.ESTADO_VENTA).Include(v => v.USUARIO).Include(v=>v.CLIENTE);
            
            ViewBag.METODOS_PAGO = db.METODO_PAGO.ToList();
            ViewBag.ESTADO = eVent; 
            return View(vENTA.ToList());
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VENTA vENTA = db.VENTA.Find(id);
            if (vENTA == null)
            {
                return HttpNotFound();
            }

            MESA mESA = db.MESA.Find(vENTA.ID_MESA);

            ViewBag.AREAIMP = db.AREA_IMPRESION.ToList();
            ViewBag.NOMBRE_MESA = mESA.NOMBRE_MESA;
            ViewBag.SALON = mESA.SALON.NOMBRE_SALON;

            return View(vENTA);
        }

        // GET: Ventas/Create
        public ActionResult Register()
        {
            var NPEDIDO = (from v in db.VENTA
                           orderby v.ID_VENTA
                           select v);

            ViewBag.NRO_PEDIDO = (NPEDIDO.ToList().Count() + 1);

            var Categorias = db.CATEGORIA.OrderBy(c => c.NOMBRE);

            //ViewBags

            ViewBag.METODOS_PAGO = db.METODO_PAGO.ToList();
            ViewBag.CATEGORIAS = Categorias.ToList();
            ViewBag.ID_MESA = new SelectList(db.MESA, "ID_MESA", "NOMBRE_MESA");
            ViewBag.ID_ESTVENTA = new SelectList(db.ESTADO_VENTA, "ID_ESTVENTA", "NOMBRE_ESTADOV");
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "CEDULA_USUARIO");
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "NOMBRE_CLIENTE"); 

            return View();
        }

        // GET: Ventas/Create
        public ActionResult Success(int? id, int? TipoRegistro)
        {
            if (id == null || TipoRegistro==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VENTA vENTA = db.VENTA.Find(id);
            MESA mESA = db.MESA.Find(vENTA.ID_MESA);

            if (vENTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.AREAIMP = db.AREA_IMPRESION.ToList();
            ViewBag.NOMBRE_MESA = mESA.NOMBRE_MESA;
            ViewBag.SALON = mESA.SALON.NOMBRE_SALON;
            ViewBag.TipoRegistro = TipoRegistro; 
            return View(vENTA);
        }


        // GET: Ventas/Create
        public ActionResult Create()
        {

            var NPEDIDO = (from v in db.VENTA
                           orderby v.ID_VENTA
                           select v);

            ViewBag.NRO_PEDIDO = (NPEDIDO.ToList().Count()+1);

            //ViewBags
            var Categorias = db.CATEGORIA.OrderBy(c => c.NOMBRE); 
            ViewBag.METODOS_PAGO = db.METODO_PAGO.ToList();
            ViewBag.CATEGORIAS = Categorias.ToList(); 
            ViewBag.ID_MESA= new SelectList(db.MESA, "ID_MESA", "NOMBRE_MESA");
            ViewBag.ID_ESTVENTA = new SelectList(db.ESTADO_VENTA, "ID_ESTVENTA", "NOMBRE_ESTADOV");
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "CEDULA_USUARIO");
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "NOMBRE_CLIENTE");

            return View();
        }




        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VENTA vENTA)
        {
            if (ModelState.IsValid)
            {
                db.VENTA.Add(vENTA);
                db.SaveChanges();
              if   (vENTA.ID_ESTVENTA==1)
                return RedirectToAction("Success", new {id= vENTA.ID_VENTA, TipoRegistro=1 });
              else
               return RedirectToAction("Success", new { id = vENTA.ID_VENTA, TipoRegistro = 2 });
            }

            var NPEDIDO = (from v in db.VENTA
                           orderby v.ID_VENTA
                           select v);

            ViewBag.NRO_PEDIDO = (NPEDIDO.ToList().Count() + 1);

            //ViewBags

            ViewBag.METODOS_PAGO = db.METODO_PAGO.ToList();
            ViewBag.CATEGORIAS = db.CATEGORIA.ToList();
            ViewBag.ID_ESTVENTA = new SelectList(db.ESTADO_VENTA, "ID_ESTVENTA", "NOMBRE_ESTADOV", vENTA.ID_ESTVENTA);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "CEDULA_USUARIO", vENTA.ID_USUARIO);
            return View(vENTA);
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTA vENTA = db.VENTA.Find(id);
            if (vENTA == null)
            {
                return HttpNotFound();
            }
           
            ViewBag.ID_ESTVENTA = new SelectList(db.ESTADO_VENTA, "ID_ESTVENTA", "NOMBRE_ESTADOV", vENTA.ID_ESTVENTA);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "CEDULA_USUARIO", vENTA.ID_USUARIO);
            return View(vENTA);
        }

        // POST: Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_VENTA,ID_USUARIO,ID_ESTVENTA,ID_CLIENTE,FECHA_VENTA,TOTAL,NRO_FACTURA,CLAVE_ACCESO,NRO_PEDIDO")] VENTA vENTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vENTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ESTVENTA = new SelectList(db.ESTADO_VENTA, "ID_ESTVENTA", "NOMBRE_ESTADOV", vENTA.ID_ESTVENTA);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "CEDULA_USUARIO", vENTA.ID_USUARIO);
            return View(vENTA);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTA vENTA = db.VENTA.Find(id);
            if (vENTA == null)
            {
                return HttpNotFound();
            }
            return View(vENTA);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VENTA vENTA = db.VENTA.Find(id);
            db.VENTA.Remove(vENTA);
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
