using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;

namespace ResumeProject.Controllers
{
    public class AboutController : Controller
    {
        DbResumeEntities1 db = new DbResumeEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult AboutBanner()
        {
            return PartialView();
        }
        public PartialViewResult PartialAboutSection()
        {
            var values = db.TblTechnology.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialVideo()
        {
            return PartialView();
        }
        public PartialViewResult PartialHireMe()
        {
            return PartialView();
        }
        public PartialViewResult PartialReferences()
        {
            var values = db.TblReferences.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialScripts()
        {
            return PartialView();
        }
    }
}