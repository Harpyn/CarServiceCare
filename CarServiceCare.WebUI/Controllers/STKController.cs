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
    public class STKController : Controller
    {
        IRepository<STK> context;

        public STKController(IRepository<STK> stkContext)
        {
            context = stkContext;
        }

        // GET: STK
        public ActionResult Index()
        {
            List<STK> stks = context.Collection().ToList();
            return View(stks);
        }
    }
}