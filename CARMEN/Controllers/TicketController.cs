using CARMEN.DTOs;
using CARMEN.Models;
using CARMEN.Service;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SaraCoffe.Controllers
{
    public class TicketController : Controller
    {


        public JsonResult PrintWhitPlugin()
        {

            PrintService pS = new PrintService();

            var client = new RestClient("http://localhost:8080");
            var request = new RestRequest("/ImpresionTermica/ticket.php", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var Body = pS.FormatPrint("EPSON");
            
            request.AddParameter("application/json", Body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            return Json(response.Content, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CashDrawer()
        {
            PrintService pS = new PrintService();

            var client = new RestClient("http://localhost:8080");
            var request = new RestRequest("/ImpresionTermica/CashDrawer.php", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var Body = pS.FormatPrint("EPSON");

            request.AddParameter("application/json", Body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            return Json(response.Content, JsonRequestBehavior.AllowGet);
        }

        // GET: Ticket
        public ActionResult Index()
        {
            PrintDocument pD = new PrintDocument();
            PrinterSettings printerSettings = new PrinterSettings();
            pD.PrinterSettings = printerSettings;
            pD.PrintPage += Imprimir;
            pD.Print();
            return RedirectToAction("Success", "Ventas", new { id = 24});
        }


            public void Imprimir(Object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial",11, FontStyle.Regular, GraphicsUnit.Point);
            int width = 200;
            int y = 20;
            e.Graphics.DrawString("                          ", font, Brushes.Black, new RectangleF(0, y+=20,width, 20));
            e.Graphics.DrawString("                          ", font, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("                          ", font, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("  Preticket               ", font, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("CAFETERIA TRADICIONAL SARA", font, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("==========VENTA=========", font, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("PedidoNro:" + "NROPEDIDO", font, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Atendido por:" + "USUARIO", font, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("====DATOS DEL CLIENTE====", font, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Nombre:" + "NROPEDIDO", font, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Identificacion:" + "NROPEDIDO", font, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Correo:" + "NROPEDIDO", font, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Telefono:" + "NROPEDIDO", font, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Direccion:" + "NROPEDIDO", font, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("                   ", font, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Cant.Descripcion     P.U Total", font, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("DETALLEVENTA", font, Brushes.Black, new RectangleF(0, y += 20, width, 20));
        }          
    }
}