using CarServiceCare.Core.Contracts;
using CarServiceCare.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CarServiceCare.WebUI.Controllers
{
    public class RefuelingController : Controller
    {
        IRepository<Refueling> context;

        public RefuelingController(IRepository<Refueling> refuelingContext)
        {
            context = refuelingContext;
        }

        // GET: Refueling
        public ActionResult Index()
        {
            List<Refueling> refuelings = context.Collection().ToList();
            return View(refuelings);
        }

        public ActionResult Create()
        {
            Refueling refueling = new Refueling();
            refueling.CreatedAt = DateTime.Now;

            return View(refueling);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Refueling refueling, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(refueling);
            }
            else
            {
                if (file != null)
                {
                    refueling.Photo = refueling.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//RefuelingImages//") + refueling.Photo);
                }

                context.Insert(refueling);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Refueling refueling = context.Find(Id);
            if (refueling == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(refueling);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Refueling refueling, string Id)
        {
            Refueling refuelingToEdit = context.Find(Id);

            if (refuelingToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(refueling);
                }

                refuelingToEdit.Car = refueling.Car;
                refuelingToEdit.Note = refueling.Note;
                refuelingToEdit.Photo = refueling.Photo;
                refuelingToEdit.Price = refueling.Price;
                refuelingToEdit.Distance = refueling.Distance;
                refuelingToEdit.DrivingStyle = refueling.DrivingStyle;
                refuelingToEdit.FuelConsumption = refueling.FuelConsumption;
                refuelingToEdit.FuelStation = refueling.FuelStation;
                refuelingToEdit.FuelType = refueling.FuelType;
                refuelingToEdit.Liters = refueling.Liters;
                refuelingToEdit.PriceForLiter = refueling.PriceForLiter;
                refuelingToEdit.Route = refueling.Route;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {

            Refueling refuelingToDelete = context.Find(Id);
            if (refuelingToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(refuelingToDelete);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {

            Refueling refuelingToDelete = context.Find(Id);
            if (refuelingToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}