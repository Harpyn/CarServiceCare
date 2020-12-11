using CarServiceCare.Core.Contracts;
using CarServiceCare.Core.Models;
using CarServiceCare.Core.ViewModels;
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
        IRepository<Car> carContext;

        public CarInsuranceController(IRepository<CarInsurance> carInsuranceContext, IRepository<Car> carContextReg)
        {
            context = carInsuranceContext;
            carContext = carContextReg;
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
            carInsurance.ValidTo = DateTime.Now;
            carInsurance.CreatedAt = DateTime.Now;

            return View(ReturnViewModel(carInsurance));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnyModelToCarViewModel<CarInsurance> viewModel, HttpPostedFileBase file)
        {

            if (!ModelState.IsValid)
            {
                return View(ReturnViewModel(viewModel.Model));
            }
            else
            {
                if (file != null)
                {
                    viewModel.Model.Photo = viewModel.Model.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//CarInsuranceImages//") + viewModel.Model.Photo);
                }

                if (viewModel.CarId != null)
                    viewModel.Model.Car = carContext.Find(viewModel.CarId);

                context.Insert(viewModel.Model);
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
                return View(ReturnViewModel(carInsurance));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnyModelToCarViewModel<CarInsurance> viewModel, string Id)
        {
            CarInsurance carInsuranceToEdit = context.Find(Id);

            if (carInsuranceToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (viewModel.CarId != null)
                    viewModel.Model.Car = carContext.Find(viewModel.CarId);

                if (!ModelState.IsValid)
                {
                    return View(ReturnViewModel(carInsuranceToEdit));
                }

                carInsuranceToEdit.Car = viewModel.Model.Car;
                carInsuranceToEdit.CreatedAt = viewModel.Model.CreatedAt;
                carInsuranceToEdit.InsuranceCompany = viewModel.Model.InsuranceCompany;
                carInsuranceToEdit.InsuranceType = viewModel.Model.InsuranceType;
                carInsuranceToEdit.Note = viewModel.Model.Note;
                carInsuranceToEdit.Photo = viewModel.Model.Photo;
                carInsuranceToEdit.Price = viewModel.Model.Price;
                carInsuranceToEdit.ValidTo = viewModel.Model.ValidTo;

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

        private AnyModelToCarViewModel<CarInsurance> ReturnViewModel(CarInsurance carInsurance)
        {
            var viewModel = new AnyModelToCarViewModel<CarInsurance>();
            viewModel.Cars = carContext.Collection().ToList();
            viewModel.Model = carInsurance;
            if (carInsurance.Car != null)
                viewModel.CarId = string.IsNullOrEmpty(carInsurance.Car.Id) ? null : carInsurance.Car.Id;
            return viewModel;
        }
    }
}