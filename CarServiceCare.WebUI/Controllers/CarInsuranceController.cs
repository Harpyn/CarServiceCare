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
    public class CarInsuranceController : Controller
    {
        IRepository<CarInsurance> context;

        public CarInsuranceController(IRepository<CarInsurance> carInsuranceContext)
        {
            context = carInsuranceContext;
        }

        // GET: CarInsurance
        public ActionResult Index()
        {
            List<CarInsurance> carInsurance = context.Collection().ToList();
            return View(carInsurance);
        }

        public ActionResult Create()
        {
            CarInsurance carInsurance = new CarInsurance();
            return View(carInsurance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarInsurance carInsurance, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(carInsurance);
            }
            else
            {
                if (file != null)
                {
                    carInsurance.Photo = carInsurance.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//CarInsuranceImages//") + carInsurance.Photo);
                }

                context.Insert(carInsurance);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            CarInsurance carInsurance = context.Find(Id);
            if (carInsurance == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(carInsurance);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarInsurance carInsurance, string Id)
        {
            CarInsurance carInsuranceToEdit = context.Find(Id);

            if (carInsuranceToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(carInsurance);
                }

                carInsuranceToEdit.Car = carInsurance.Car;
                carInsuranceToEdit.CreatedAt = carInsurance.CreatedAt;
                carInsuranceToEdit.InsuranceCompany = carInsurance.InsuranceCompany;
                carInsuranceToEdit.InsuranceType = carInsurance.InsuranceType;
                carInsuranceToEdit.Note = carInsurance.Note;
                carInsuranceToEdit.Photo = carInsurance.Photo;
                carInsuranceToEdit.Price = carInsurance.Price;
                carInsuranceToEdit.ValidTo = carInsurance.ValidTo;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {

            CarInsurance carInsuranceToDelete = context.Find(Id);
            if (carInsuranceToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(carInsuranceToDelete);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {

            CarInsurance carInsuranceToDelete = context.Find(Id);
            if (carInsuranceToDelete == null)
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