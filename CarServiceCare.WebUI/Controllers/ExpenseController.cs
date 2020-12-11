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
    public class ExpenseController : Controller
    {
        IRepository<Expense> context;
        IRepository<Car> carContext;


        public ExpenseController(IRepository<Expense> expenseContext, IRepository<Car> carContextReg)
        {
            context = expenseContext;
            carContext = carContextReg;
        }

        // GET: Expense
        public ActionResult Index()
        {
            List<Expense> expenses = context.Collection().ToList();
            return View(expenses);
        }

        public ActionResult Create()
        {
            Expense expense = new Expense();
            expense.CreatedAt = DateTime.Now;

            return View(ReturnViewModel(expense));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnyModelToCarViewModel<Expense> viewModel, HttpPostedFileBase file)
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
                    file.SaveAs(Server.MapPath("//Content//ExpenseImages//") + viewModel.Model.Photo);
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
            Expense expense = context.Find(Id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(ReturnViewModel(expense));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnyModelToCarViewModel<Expense> viewModel, string Id)
        {
            Expense expenseToEdit = context.Find(Id);

            if (expenseToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (viewModel.CarId != null)
                    viewModel.Model.Car = carContext.Find(viewModel.CarId);

                if (!ModelState.IsValid)
                {
                    return View(ReturnViewModel(expenseToEdit));
                }

                expenseToEdit.Car = viewModel.Model.Car;
                expenseToEdit.CreatedAt = viewModel.Model.CreatedAt;
                expenseToEdit.Type = viewModel.Model.Type;
                expenseToEdit.Note = viewModel.Model.Note;
                expenseToEdit.Price = viewModel.Model.Price;         

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {

            Expense expenseToDelete = context.Find(Id);
            if (expenseToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(expenseToDelete);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {

            Expense expenseToDelete = context.Find(Id);
            if (expenseToDelete == null)
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

        private AnyModelToCarViewModel<Expense> ReturnViewModel(Expense expense)
        {
            var viewModel = new AnyModelToCarViewModel<Expense>();
            viewModel.Cars = carContext.Collection().ToList();
            viewModel.Model = expense;
            if (expense.Car != null)
                viewModel.CarId = string.IsNullOrEmpty(expense.Car.Id) ? null : expense.Car.Id;
            return viewModel;
        }

    }
}