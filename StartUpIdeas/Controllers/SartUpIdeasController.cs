using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StartUpIdeas.Models;
using StartUpIdeas.Repositories;
using StartUpIdeas.DAL;

namespace StartUpIdeas.Controllers
{
    public class StartUpIdeasController : Controller
    {
        private IRepository<StartUpIdea, int> _repository;

        public StartUpIdeasController(IRepository<StartUpIdea, int> repo)
        {
            _repository = repo;
        }


        // GET: SartUpIdeas
        public ActionResult Index()
        {
            return View();
        }

        // GET: SartUpIdeas/Details/5
        public ActionResult Details(int id)
        {
            StartUpIdea si = _repository.Get(id);


            return View(si);
        }

        // GET: SartUpIdeas/Create
        public ActionResult Submit()
        {
            return View();
        }

        // POST: SartUpIdeas/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                StartUpIdeaViewModel startUpUdeaVM = new StartUpIdeaViewModel();
                StartUpIdea si = new StartUpIdea();


                si.ProjectName = collection["ProjectName"];
                si.ProjectDescription = collection["ProjectDescription"];
                si.FirstName = collection["FirstName"];
                si.LastName = collection["LastName"];
                si.Email = collection["Email"];
                si.SubmitedDateTime = DateTime.Now;
                si.UpdatedDateTime = DateTime.Now;

                _repository.Add(si);

                

                return RedirectToAction("Submit");
            }
            catch(Exception e)
            {
                ViewBag.ErrMsg = e.Message + ":" + e.InnerException;
                return View("Submit");
            }
        }

        // GET: SartUpIdeas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SartUpIdeas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SartUpIdeas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SartUpIdeas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
