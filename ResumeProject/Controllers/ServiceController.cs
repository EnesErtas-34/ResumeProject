using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;

namespace ResumeProject.Controllers
{
    public class ServiceController : Controller
    {
        DbResumeEntities1 db = new DbResumeEntities1();
        public ActionResult Index()
        {
            var values = db.TblService.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(TblService p)
        {
            db.TblService.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DeleteService(int id)
        {
            var values = db.TblService.Find(id);
            db.TblService.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult updateService(int id)
        {
            var values = db.TblService.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult updateService(TblService p)
        {
            var values = db.TblService.Find(p.ServiceID);
            values.ServiceTitle = p.ServiceTitle;
            values.ServiceDescription = p.ServiceDescription;
            values.Serviceicon = p.Serviceicon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
  
        public ActionResult Service()
        {
            return View();
        }
        public PartialViewResult PartialServiceBanner()
        {
            return PartialView();
        }
     
    }
}