using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTB.Data;

namespace TTB.Web.Controllers
{
    [RoutePrefix("PickList")]
    public class PickListController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var vm = new PickListViewModel();
            vm.HandleRequest();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(PickListViewModel vm)
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

        [HttpGet]
        public ActionResult ShowDomestic()
        {
            var vm = new PickListViewModel();
            vm.SearchEntity.DIFlag = "D";
            vm.HandleRequest();
            return View("Index",vm);
        }

        [HttpPost]
        public ActionResult ShowDomestic(PickListViewModel vm)
        {
            vm.IsValid = ModelState.IsValid; // mvc sets this based on the data annotations
            vm.SearchEntity.DIFlag = "D";
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

            return View("Index",vm);
        }

        [HttpGet]
        public ActionResult ShowInternational()
        {
            var vm = new PickListViewModel();
            vm.SearchEntity.DIFlag = "I";
            vm.HandleRequest();
            return View("Index",vm);
        }

        [HttpPost]
        public ActionResult ShowInternational(PickListViewModel vm)
        {
            vm.IsValid = ModelState.IsValid; // mvc sets this based on the data annotations
            vm.SearchEntity.DIFlag = "I";
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

            return View("Index",vm);
        }


    }
}