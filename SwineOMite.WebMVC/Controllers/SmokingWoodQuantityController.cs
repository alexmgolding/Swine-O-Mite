using SwineOMite.Models.SmokingWoodQuantity;
using SwineOMite.Models.SmookingWoodQuantity;
using SwineOMite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwineOMite.WebMVC.Controllers
{
    [Authorize]
    public class SmokingWoodQuantityController : Controller
    {
        // GET: SmokingWoodQuantity
        [HttpGet]
        public ActionResult Index()
        {
            var service = new SmokingWoodQuantityService();
            var model = service.GetSmokingWoodQauntities();
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
        public ActionResult Create(SmokingWoodQuantityCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateSmokingWoodQuantityService();

            if (service.CreateSmokingWoodQuantity(model))
            {
                TempData["SaveResult"] = "Your smoking wood quantity was stored.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your smoking wood quantity could not be stored.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSmokingWoodQuantityService();
            var model = svc.GetSmokingWoodQuantityById(id);

            return View(model);
        }

        private SmokingWoodQuantityService CreateSmokingWoodQuantityService()
        {
            var service = new SmokingWoodQuantityService();
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSmokingWoodQuantityService();
            var detail = service.GetSmokingWoodQuantityById(id);
            var model = new SmokingWoodQuantityEdit
            {
                SmokingWoodQuantityId = detail.SmokingWoodQuantityId,
                SmokingWoodId = detail.SmokingWoodId,
                WoodQuantityId = detail.WoodQuantityId
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SmokingWoodQuantityEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SmokingWoodQuantityId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateSmokingWoodQuantityService();

            if (service.UpdateSmokingWoodQuantity(model))
            {
                TempData["SaveResult"] = "Your smoking wood quantity was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your smoking wood quantity didn't updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSmokingWoodQuantityService();
            var model = svc.GetSmokingWoodQuantityById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteIngredient(int id)
        {
            var service = CreateSmokingWoodQuantityService();
            service.DeleteSmokingWoodQuantity(id);
            TempData["SaveResult"] = "Your smoking wood quantity was removed.";
            return RedirectToAction("Index");
        }
    }
}