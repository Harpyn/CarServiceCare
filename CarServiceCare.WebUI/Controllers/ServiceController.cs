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
    public class ServiceController : Controller
    {
        IRepository<Service> context;

        public ServiceController(IRepository<Service> serviceContext)
        {
            context = serviceContext;
        }

        // GET: Service
        public ActionResult Index()
        {
            List<Service> services = context.Collection().ToList();
            return View(services);
        }
    }
}