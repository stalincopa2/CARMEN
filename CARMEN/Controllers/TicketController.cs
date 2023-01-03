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
        private RestClient client = new RestClient("http://localhost:8080");
        private RestRequest request = null;


        public JsonResult PrintWhitPlugin(Ticket ticket)
        {
            if (ticket.Tipo == 1)
            {
                 request = new RestRequest("/ImpresionTermica/ticket.php", Method.Post);
            }
            else
            {
                 request = new RestRequest("/ImpresionTermica/Comanda.php", Method.Post);
            }
           
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonSerializer.Serialize(ticket), ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            return Json(response.Content, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CashDrawer()
        {
            var request = new RestRequest("/ImpresionTermica/CashDrawer.php", Method.Post);

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "SN ", ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            return Json(response.Content, JsonRequestBehavior.AllowGet);
        }         
    }
}