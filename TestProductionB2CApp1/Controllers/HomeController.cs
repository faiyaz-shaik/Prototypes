using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;


namespace TestProductionB2CApp1.Controllers
{
   
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

      

         async Task  ProcessUserRecordsAsync()
        {
            HttpClient client = new HttpClient();

           string content =  await client.GetStringAsync("http://www.bbc.co.uk");

           
        }

    }
}