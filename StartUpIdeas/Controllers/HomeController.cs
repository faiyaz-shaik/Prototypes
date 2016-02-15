using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StartUpIdeas.DAL;
using StartUpIdeas.Repositories;

namespace StartUpIdeas.Controllers
{
    
    public class HomeController : Controller
    {
        
        private IRepository<StartUpIdea, int> _repository;

        public HomeController(IRepository< StartUpIdea, int> repo)
        {
            _repository = repo;
        }

        public ActionResult Index()
        {

            var startupideas = _repository.Get();

            return View(startupideas);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Please submit your StartUp ideas.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}