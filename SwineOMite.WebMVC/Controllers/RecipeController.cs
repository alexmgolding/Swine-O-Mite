using SwineOMite.Models.Recipe;
using SwineOMite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwineOMite.WebMVC.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        [HttpGet]
        public ActionResult Index()
        {
            var service = new RecipeService();
            var model = service.GetRecipes();
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
        public ActionResult Create(RecipeCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateRecipeService();

            if (service.CreateRecipe(model))
            {
                TempData["SaveResult"] = "Your recipe was stored.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your recipe could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRecipeService();
            var model = svc.GetRecipeById(id);

            return View(model);
        }

        private RecipeService CreateRecipeService()
        {
            var service = new RecipeService();
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRecipeService();
            var detail = service.GetRecipeById(id);
            var model = new RecipeEdit
            {
                RecipeId = detail.RecipeId,
                RecipeTitle = detail.RecipeTitle,
                DateCreated = detail.DateCreated,
                CompleteIngredients = detail.CompleteIngredients,
                SmokingWoodQuantities = detail.SmokingWoodQuantities,
                DirectionId = detail.DirectionId
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecipeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RecipeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRecipeService();

            if (service.UpdateRecipe(model))
            {
                TempData["SaveResult"] = "Your recipe was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your recipe wasn't updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRecipeService();
            var model = svc.GetRecipeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecipe(int id)
        {
            var service = CreateRecipeService();
            service.DeleteRecipe(id);
            TempData["SaveResult"] = "Your recipe was removed.";
            return RedirectToAction("Index");
        }
    }
}