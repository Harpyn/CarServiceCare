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
    public class CarController : Controller
    {
        IRepository<Car> context;

        public CarController(IRepository<Car> carContext)
        {
            context = carContext;
        }


        // GET: Cars
        public ActionResult Index()
        {
            List<Car> cars = context.Collection().ToList();
            return View(cars);
        }

        public ActionResult Create()
        {
            Car car = new Car();
            return View(car);
        }

        [HttpPost]
        public ActionResult Create(Car car, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }
            else
            {

                if (file != null)
                {
                    car.Photo = car.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//CarImages//") + car.Photo);
                }

                context.Insert(car);
                context.Commit();
                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(string Id)
        {
            Car car = context.Find(Id);
            if (car == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(car);
            }
        }

        [HttpPost]
        public ActionResult Edit(Car car, string Id, HttpPostedFileBase file)
        {
            Car carToEdit = context.Find(Id);
            if (carToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(car);
                }

                if (file != null)
                {
                    car.Photo = car.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//CarImages//") + car.Photo);
                }

                carToEdit.CarBrand = car.CarBrand;
                carToEdit.CarInsurances = car.CarInsurances;
                carToEdit.Category = car.Category;
                carToEdit.Color = car.Color;
                carToEdit.CreatedAt = car.CreatedAt;
                carToEdit.CubicCapacity = car.CubicCapacity;
                carToEdit.DateOfPurchase = car.DateOfPurchase;
                carToEdit.Expenses = car.Expenses;
                carToEdit.FirstRegistration = car.FirstRegistration;
                carToEdit.FuelType = car.FuelType;
                carToEdit.Kilometer = car.Kilometer;
                carToEdit.LicensePlate = car.LicensePlate;
                carToEdit.Model = car.Model;
                carToEdit.Note = car.Note;
                carToEdit.Owners = car.Owners;
                carToEdit.Power = car.Power;
                carToEdit.Price = car.Price;
                carToEdit.Refuelings = car.Refuelings;
                carToEdit.Repairs = car.Repairs;
                carToEdit.Services = car.Services;
                carToEdit.STK = car.STK;
                carToEdit.TireChanges = car.TireChanges;
                carToEdit.VehicleType = car.VehicleType;
                carToEdit.VIN = car.VIN;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {

            Car carToDelete = context.Find(Id);
            if (carToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(carToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {

            Car carToDelete = context.Find(Id);
            if (carToDelete == null)
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