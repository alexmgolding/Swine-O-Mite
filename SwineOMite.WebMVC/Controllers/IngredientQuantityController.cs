using SwineOMite.Models.IngredientQuantities;
using SwineOMite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwineOMite.WebMVC.Controllers
{
    [Authorize]
    public class IngredientQuantityController : Controller
    {
        // GET: IngredientQuantity
        [HttpGet]
        public ActionResult Index()
        {
            var service = new IngredientQuantityService();
            var model = service.GetIngredientQuantity();
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
        public ActionResult Create(IngredientQuantityCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateIngredientQuantityService();

            if (service.CreateIngredientQuantity(model))
            {
                TempData["SaveResult"] = "Your ingredient was stored.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Ingredient quantity could not be stored.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateIngredientQuantityService();
            var model = svc.GetIngredientQuantityById(id);

            return View(model);
        }

        private IngredientQuantityService CreateIngredientQuantityService()
        {
            var service = new IngredientQuantityService();
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateIngredientQuantityService();
            var detail = service.GetIngredientQuantityById(id);
            var model = new IngredientQuantityEdit
            {
                QuantityId = detail.QuantityId,
                IngredentAmount = detail.IngredentAmount,
                MeasurementUnit = detail.MeasurementUnit
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IngredientQuantityEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.QuantityId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateIngredientQuantityService();

            if (service.UpdateIngredientQuantity(model))
            {
                TempData["SaveResult"] = "Your ingredient quantity was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your ingredient quantity wasn't updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateIngredientQuantityService();
            var model = svc.GetIngredientQuantityById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteIngredient(int id)
        {
            var service = CreateIngredientQuantityService();
            service.DeleteIngredientQuantity(id);
            TempData["SaveResult"] = "Your ingredient quantity was removed.";
            return RedirectToAction("Index");
        }
    }
}