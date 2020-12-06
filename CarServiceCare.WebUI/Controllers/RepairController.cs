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

        public ActionResult Create()
        {
            Repair repair = new Repair();
            repair.CreatedAt = DateTime.Now;

            return View(repair);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Repair repair, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(repair);
            }
            else
            {
                if (file != null)
                {
                    repair.Photo = repair.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//RepairImages//") + repair.Photo);
                }

                context.Insert(repair);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Repair repair = context.Find(Id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(repair);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Repair repair, string Id)
        {
            Repair repairToEdit = context.Find(Id);

            if (repairToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(repair);
                }

                repairToEdit.Car = repair.Car;
                repairToEdit.Note = repair.Note;
                repairToEdit.Photo = repair.Photo;
                repairToEdit.EstimatedPrice = repair.EstimatedPrice;
                repairToEdit.Priority = repair.Priority;
                repairToEdit.RepairType = repair.RepairType;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {

            Repair repairToDelete = context.Find(Id);
            if (repairToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(repairToDelete);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {

            Repair repairToDelete = context.Find(Id);
            if (repairToDelete == null)
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