using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;

namespace ResumeProject.Controllers
{
    public class ContactController : Controller
    {
        DbResumeEntities1 db = new DbResumeEntities1();
        public ActionResult Index()
        {
            var value = db.TblContact.ToList();
            return View(value);
        }

        public ActionResult DeleteMessage(int id)
        {
            var values = db.TblContact.Find(id);
            db.TblContact.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult SendMessage()
        {
            List<SelectListItem> values = (from x in db.TblCategory.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult SendMessage(TblContact p)
        {
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblContact.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index","Default");//Default dedik aynı controllerin içinde admin paneli olan ındexe giderdi.
        }

        public PartialViewResult PartialMap()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            return PartialView();
        }


    }
}