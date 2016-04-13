using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FazStock.Models;
using PagedList;

namespace FazStock.Controllers
{
    public class ProductsController : Controller
    {
        private fazstockEntities db = new fazstockEntities();

        protected override  void  OnActionExecuting(
    ActionExecutingContext filterContext

)
        {
            if (Session["LoggedInUser"] == null)
            {
                filterContext.Result =    RedirectToAction("Index", "Login", new { area = "Products" });
                return;
            }
            else
            {
                return;
            }
        }
        

        // GET: Products
        //public async Task<ActionResult> Index()
        //{
        //    return View(await db.Products.ToListAsync());
        //}

        public  ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ItemNameSortParm = String.IsNullOrEmpty(sortOrder) ? "ItemName_Dec" : "";
            // ViewBag.ItemNumberSortParm = String.IsNullOrEmpty(sortOrder) ? "ItemNumber" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var products = from p in db.Products
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.ItemName.Contains(searchString)
                                       || p.ItemNumber.Contains(searchString));
            }

            switch (sortOrder)
            {

                case "ItemName_Dec":
                    products = products.OrderByDescending(p => p.ItemName);
                    break;

                case "ItemNumber":
                    products = products.OrderByDescending(p => p.ItemNumber);
                    break;

                default:
                    products = products.OrderBy(p => p.ItemName);
                    break;

            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(products.ToPagedList(pageNumber, pageSize));
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ItemNumber,ItemName,ebayOurPrice,ebayComptetionPrice,StockLevel,Sold,StockLeft,BestSelling,Comments")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ItemNumber,ItemName,ebayOurPrice,ebayComptetionPrice,StockLevel,Sold,StockLeft,BestSelling,Comments")] Product product)
        {
            if (ModelState.IsValid)
            {
              
                product.StockLeft = product.StockLevel - product.Sold;
                
                db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
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
