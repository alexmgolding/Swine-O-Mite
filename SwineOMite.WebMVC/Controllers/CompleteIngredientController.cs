using SwineOMite.Models.CompleteIngredient;
using SwineOMite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwineOMite.WebMVC.Controllers
{
    [Authorize]
    public class CompleteIngredientController : Controller
    {
        // GET: CompleteIngredient
        [HttpGet]
        public ActionResult Index()
        {
            var service = new CompleteIngredientService();
            var model = service.GetCompleteIngredients();
            return View(model);
        }

        // GET:
        [HttpGet]
        public ActionResult Create()
        {
            var model = new CompleteIngredientCreate();
            model.Ingredient = new IngredientService().GetIngredientDropdown();

            model.IngredientQuantity = new IngredientQuantityService().GetIngredientQuantityDropdown();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompleteIngredientCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateCompleteIngredientService();

            if (service.CreateCompleteIngredient(model))
            {
                TempData["SaveResult"] = "Your complete ingredient was stored.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your complete ingredient could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCompleteIngredientService();
            var model = svc.GetCompleteIngredientById(id);

            return View(model);
        }

        private CompleteIngredientService CreateCompleteIngredientService()
        {
            var service = new CompleteIngredientService();
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCompleteIngredientService();
            var detail = service.GetCompleteIngredientById(id);
            var model = new CompleteIngredientEdit
            {
                CompleteIngredientId = detail.CompleteIngredientId,
                IngredientId = detail.IngredientId,
                QuantityId = detail.QuantityId
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CompleteIngredientEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CompleteIngredientId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCompleteIngredientService();

            if (service.UpdateCompleteIngredient(model))
            {
                TempData["SaveResult"] = "Your complete ingredient updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your complete ingredient wasn't updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCompleteIngredientService();
            var model = svc.GetCompleteIngredientById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCompleteIngredient(int id)
        {
            var service = CreateCompleteIngredientService();
            service.DeleteCompleteIngredient(id);
            TempData["SaveResult"] = "You've deleted your complete ingredient.";
            return RedirectToAction("Index");
        }
    }
}