using SwineOMite.Models.WoodQuantity;
using SwineOMite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwineOMite.WebMVC.Controllers
{
    public class WoodQuantityController : Controller
    {
        // GET: WoodQuantity
        [HttpGet]
        public ActionResult Index()
        {
            var service = new WoodQuantityService();
            var model = service.GetWoodQuantity();
            return View(model);
        }

        // GET:
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WoodQuantityCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateWoodQuantityService();

            if (service.CreateWoodQuantity(model))
            {
                TempData["SaveResult"] = "Your wood quantity was stored.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your wood quantity couldn't be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateWoodQuantityService();
            var model = svc.GetWoodQuantityById(id);

            return View(model);
        }

        private WoodQuantityService CreateWoodQuantityService()
        {
            var service = new WoodQuantityService();
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateWoodQuantityService();
            var detail = service.GetWoodQuantityById(id);
            var model = new WoodQuantityEdit
            {
                WoodQuantityId = detail.WoodQuantityId,
                WoodAmount = detail.WoodAmount
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WoodQuantityEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.WoodQuantityId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateWoodQuantityService();

            if (service.UpdateWoodQuantity(model))
            {
                TempData["SaveResult"] = "Your wood quantity was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your wood quantity wasn't updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateWoodQuantityService();
            var model = svc.GetWoodQuantityById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteWoodQuantity(int id)
        {
            var service = CreateWoodQuantityService();
            service.DeleteWoodQuantity(id);
            TempData["SaveResult"] = "Your wood quantity was removed.";
            return RedirectToAction("Index");
        }
    }
}