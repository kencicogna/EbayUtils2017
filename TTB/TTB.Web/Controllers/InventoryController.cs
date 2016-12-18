using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTB.Repository;
using TTB.Data;

namespace TTB.Web.Controllers
{
    public class InventoryController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var vm = new InventoryViewModel();
            vm.HandleRequest();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(InventoryViewModel vm)
        {
            vm.IsValid = ModelState.IsValid; // mvc sets this based on the data annotations
            vm.HandleRequest();

            if (vm.IsValid)
            {
                ModelState.Clear();
            }
            else
            {
                foreach (KeyValuePair<string, string> item in vm.ValidationErrors)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
            }

            return View(vm);
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
    }
}