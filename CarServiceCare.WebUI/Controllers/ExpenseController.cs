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
    public class ExpenseController : Controller
    {
        IRepository<Expense> context;

        public ExpenseController(IRepository<Expense> expenseContext)
        {
            context = expenseContext;
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
            return View(expense);
        }

        [HttpPost]
        public ActionResult Create(Expense expense, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(expense);
            }
            else
            {
                if (file != null)
                {
                    expense.Photo = expense.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ExpenseImages//") + expense.Photo);
                }

                context.Insert(expense);
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
                return View(expense);
            }
        }

        [HttpPost]
        public ActionResult Edit(Expense expense, string Id)
        {
            Expense expenseToEdit = context.Find(Id);
            if (expenseToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(expense);
                }

                expenseToEdit.Car = expense.Car;
                expenseToEdit.CreatedAt = expense.CreatedAt;
                expenseToEdit.Type = expense.Type;
                expenseToEdit.Note = expense.Note;
                expenseToEdit.Price = expense.Price;         

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
    }
}