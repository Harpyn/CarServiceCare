using CarServiceCare.Core.Contracts;
using CarServiceCare.Core.Models;
using System;
using System.Collections.Generic;
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


        // GET: Car
        public ActionResult Index()
        {
            return View();
        }
    }
}