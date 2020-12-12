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
    public class RefuelingController : Controller
    {
        IRepository<Refueling> context;
        IRepository<Car> carContext;

        public RefuelingController(IRepository<Refueling> refuelingContext, IRepository<Car> carContextReg)
        {
            context = refuelingContext;
            carContext = carContextReg;
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

            return View(ReturnViewModel(refueling));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnyModelToCarViewModel<Refueling> viewModel, HttpPostedFileBase file)
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
                    file.SaveAs(Server.MapPath("//Content//RefuelingImages//") + viewModel.Model.Photo);
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
            Refueling refueling = context.Find(Id);
            if (refueling == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(ReturnViewModel(refueling));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnyModelToCarViewModel<Refueling> viewModel, string Id)
        {
            Refueling refuelingToEdit = context.Find(Id);

            if (refuelingToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (viewModel.CarId != null)
                    viewModel.Model.Car = carContext.Find(viewModel.CarId);

                if (!ModelState.IsValid)
                {
                    return View(ReturnViewModel(refuelingToEdit));
                }

                refuelingToEdit.Car = viewModel.Model.Car;
                refuelingToEdit.Note = viewModel.Model.Note;
                refuelingToEdit.Photo = viewModel.Model.Photo;
                refuelingToEdit.Price = viewModel.Model.Price;
                refuelingToEdit.Distance = viewModel.Model.Distance;
                refuelingToEdit.DrivingStyle = viewModel.Model.DrivingStyle;
                refuelingToEdit.FuelConsumption = viewModel.Model.FuelConsumption;
                refuelingToEdit.FuelStation = viewModel.Model.FuelStation;
                refuelingToEdit.FuelType = viewModel.Model.FuelType;
                refuelingToEdit.Liters = viewModel.Model.Liters;
                refuelingToEdit.PriceForLiter = viewModel.Model.PriceForLiter;
                refuelingToEdit.Route = viewModel.Model.Route;

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

        private AnyModelToCarViewModel<Refueling> ReturnViewModel(Refueling refueling)
        {
            var viewModel = new AnyModelToCarViewModel<Refueling>();
            viewModel.Cars = carContext.Collection().ToList();
            viewModel.Model = refueling;
            if (refueling.Car != null)
                viewModel.CarId = string.IsNullOrEmpty(refueling.Car.Id) ? null : refueling.Car.Id;
            return viewModel;
        }
    }
}