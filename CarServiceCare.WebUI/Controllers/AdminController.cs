using CarServiceCare.Core.Contracts;
using CarServiceCare.Core.Models;
using CarServiceCare.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarServiceCare.WebUI.Controllers
{
    public class AdminController : Controller
    {
        IRepository<Car> carContext;
        IRepository<CarInsurance> carInsuranceContext;
        IRepository<Expense> expenseContext;
        IRepository<Refueling> refuelingContext;
        IRepository<Repair> repairContext;
        IRepository<Service> serviceContext;
        IRepository<STK> stkContext;
        IRepository<TireChange> tireChangeContext;
        IRepository<User> userContext;

        public AdminController(IRepository<Car> carContext, IRepository<CarInsurance> carInsuranceContext, IRepository<Expense> expenseContext, IRepository<Refueling> refuelingContext, IRepository<Repair> repairContext, IRepository<Service> serviceContext, IRepository<STK> stkContext, IRepository<TireChange> tireChangeContext, IRepository<User> userContext)
        {
            this.carContext = carContext;
            this.carInsuranceContext = carInsuranceContext;
            this.expenseContext = expenseContext;
            this.refuelingContext = refuelingContext;
            this.repairContext = repairContext;
            this.serviceContext = serviceContext;
            this.stkContext = stkContext;
            this.tireChangeContext = tireChangeContext;
            this.userContext = userContext;
        }

        // GET: Admin
        public ActionResult Index()
        {
            var viewModel = new AdminViewModel
            {
                Cars = carContext.Collection().ToList(),
                CarInsurances = carInsuranceContext.Collection().ToList(),
                Expenses = expenseContext.Collection().ToList(),
                Refuelings = refuelingContext.Collection().ToList(),
                Repairs = repairContext.Collection().ToList(),
                Services = serviceContext.Collection().ToList(),
                STK = stkContext.Collection().ToList(),
                TireChanges = tireChangeContext.Collection().ToList(),
                Users = userContext.Collection().ToList()
          
            };
            return View(viewModel);
        }
    }
}