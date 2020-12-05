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
    public class TireChangeController : Controller
    {
        IRepository<TireChange> context;

        public TireChangeController(IRepository<TireChange> tireChangeContext)
        {
            context = tireChangeContext;

        }
        // GET: TireChange
        public ActionResult Index()
        {
            List<TireChange> tireChanges = context.Collection().ToList();
            return View(tireChanges);
        }
    }
}