using SwineOMite.Models.Directions;
using SwineOMite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwineOMite.WebMVC.Controllers
{
    public class DirectionController : Controller
    {
        // GET: Direction
        [HttpGet]
        public ActionResult Index()
        {
            var service = new DirectionService();
            var model = service.GetDirections();
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
        public ActionResult Create(DirectionCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateDirectionService();

            if (service.CreateDirection(model))
            {
                TempData["SaveResult"] = "You're Direction was stored.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Direction could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateDirectionService();
            var model = svc.GetDirectionById(id);

            return View(model);
        }

        private DirectionService CreateDirectionService()
        {
            var service = new DirectionService();
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateDirectionService();
            var detail = service.GetDirectionById(id);
            var model = new DirectionEdit
            {
                DirectionId = detail.DirectionId,
                StepNumber = detail.StepNumber,
                Instructions = detail.Instructions
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DirectionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.DirectionId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateDirectionService();

            if (service.UpdateDirection(model))
            {
                TempData["SaveResult"] = "Your direction was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your direction wasn't updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateDirectionService();
            var model = svc.GetDirectionById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDirection(int id)
        {
            var service = CreateDirectionService();
            service.DeleteDirection(id);
            TempData["SaveResult"] = "Your direction was removed.";
            return RedirectToAction("Index");
        }
    }
}