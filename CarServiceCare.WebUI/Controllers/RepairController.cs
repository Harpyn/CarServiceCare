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
    public class RepairController : Controller
    {
        IRepository<Repair> context;

        public RepairController(IRepository<Repair> repairContext)
        {
            context = repairContext;

        }
        // GET: Repair
        public ActionResult Index()
        {
            List<Repair> repairs = context.Collection().ToList();
            return View(repairs);
        }
    }
}