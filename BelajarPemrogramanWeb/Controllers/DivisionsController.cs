using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BelajarPemrogramanWeb.Controllers
{
    public class DivisionsController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44338/API/")
        };

        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LoadDivision()
        {
            IEnumerable<Division> divisions = null;
            var responseTask = client.GetAsync("Divisions");
            responseTask.Wait();
            var result = responseTask.Result;
            // status code
            if(result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Division>>();
                readTask.Wait();
                divisions = readTask.Result;
            }

            return new JsonResult
            {
                Data = divisions,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            
        }
    }
}