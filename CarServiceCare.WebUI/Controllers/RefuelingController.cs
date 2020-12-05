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
    }
}