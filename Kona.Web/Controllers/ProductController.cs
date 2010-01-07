using System.Web.Mvc;
using Kona.App.Services;

namespace Kona.Controllers
{
    public class ProductController : Controller
    {

        IStoreService _service;

        public ProductController(IStoreService service)
        {
            _service = service;
        }

        public ActionResult Search(string query)
        {
            return Content("hook me up");
        }
        //
        // GET: /Product/

        public ActionResult Index(int? id)
        {
            //ProductListViewModel model=null;
            ////if an ID is sent in it's a category
            //if (id.HasValue) {
            //    model = _service.GetCategoryModel((int)id);
            //} else {
            //    RedirectToAction("Index", "Home");
            //}
            //return View(model);
            return Content("Success");
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(string id)
        {

            var model = _service.GetDetails(id);
            return View(model);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Product/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Product/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
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
    }
}
