using SwineOMite.Models.SmookingWood;
using SwineOMite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwineOMite.WebMVC.Controllers
{
    public class SmokingWoodController : Controller
    {
        // GET: SmokingWood
        [HttpGet]
        public ActionResult Index()
        {
            var service = new SmokingWoodService();
            var model = service.GetSmokingWood();
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
        public ActionResult Create(SmokingWoodCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateSmokingWoodService();

            if (service.CreateSmokingWood(model))
            {
                TempData["SaveResult"] = "Your smooking wood was stored.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your smoking wood couldn't be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSmokingWoodService();
            var model = svc.GetSmokingWoodById(id);

            return View(model);
        }

        private SmokingWoodService CreateSmokingWoodService()
        {
            var service = new SmokingWoodService();
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSmokingWoodService();
            var detail = service.GetSmokingWoodById(id);
            var model = new SmokingWoodEdit
            {
                SmokingWoodId = detail.SmokingWoodId,
                WoodSpecies = detail.WoodSpecies,
                WoodVariety = detail.WoodVariety
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SmokingWoodEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SmokingWoodId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateSmokingWoodService();

            if (service.UpdateSmokingWood(model))
            {
                TempData["SaveResult"] = "Your smoking wood was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your smoking wood wasn't updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSmokingWoodService();
            var model = svc.GetSmokingWoodById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSmokingWood(int id)
        {
            var service = CreateSmokingWoodService();
            service.DeleteSmokingWood(id);
            TempData["SaveResult"] = "Your smoking wood was removed.";
            return RedirectToAction("Index");
        }
    }
}