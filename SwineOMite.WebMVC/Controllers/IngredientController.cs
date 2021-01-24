using Microsoft.AspNet.Identity;
using SwineOMite.Models;
using SwineOMite.Models.Ingredient;
using SwineOMite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwineOMite.WebMVC.Controllers
{
    [Authorize]
    public class IngredientController : Controller
    {
        // GET: Ingredient
        [HttpGet]
        public ActionResult Index()
        {            
            var service = new IngredientService();
            var model = service.GetIngredients();
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
        public ActionResult Create(IngredientCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateIngredientService();

            if (service.CreateIngredient(model))
            {
                TempData["SaveResult"] = "Your ingredient was stored.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your ingredient could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateIngredientService();
            var model = svc.GetIngredientById(id);

            return View(model);
        }

        private IngredientService CreateIngredientService()
        {
            var service = new IngredientService();
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateIngredientService();
            var detail = service.GetIngredientById(id);
            var model = new IngredientEdit
            {
                IngredientId = detail.IngredientId,
                IngredientName = detail.IngredientName
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IngredientEdit model)
        {
            if(!ModelState.IsValid) return View(model);

            if(model.IngredientId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            
            var service = CreateIngredientService();

            if (service.UpdateIngredient(model))
            {
                TempData["SaveResult"] = "Your ingredient was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your ingredient wasn't updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateIngredientService();
            var model = svc.GetIngredientById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteIngredient(int id)
        {
            var service = CreateIngredientService();
            service.DeleteIngredient(id);
            TempData["SaveResult"] = "Your ingredient was removed.";
            return RedirectToAction("Index");
        }
    }
}