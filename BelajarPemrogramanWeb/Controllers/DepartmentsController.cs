using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BelajarPemrogramanWeb.Controllers
{
    public class DepartmentsController : Controller
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

        public JsonResult LoadDepartment()
        {
            IEnumerable<Department> departments = null;
            var responseTask = client.GetAsync("Departments");
            responseTask.Wait();
            var result = responseTask.Result;
            // status code
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Department>>();
                readTask.Wait();
                departments = readTask.Result;
            }

            return new JsonResult
            {
                Data = departments,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}