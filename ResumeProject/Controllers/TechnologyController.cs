using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;

namespace ResumeProject.Controllers
{
    public class TechnologyController : Controller
    {
        DbResumeEntities1 db = new DbResumeEntities1();
        public ActionResult Index()
        {
            var values = db.TblTechnology.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddTechnology()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTechnology(TblTechnology p)
        {
            db.TblTechnology.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTechnology(int id)
        {
            var value = db.TblTechnology.Find(id);
            db.TblTechnology.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTechnology(int id)
        {
            var value = db.TblTechnology.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTechnology(TblTechnology p)
        {
            var value = db.TblTechnology.Find(p.TechnologyID);
            value.TechnologyTitle = p.TechnologyTitle;
            value.TechnologyValue = p.TechnologyValue;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}