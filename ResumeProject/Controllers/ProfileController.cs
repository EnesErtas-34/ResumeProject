using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;

namespace ResumeProject.Controllers
{
    public class ProfileController : Controller
    {
        DbResumeEntities1 db = new DbResumeEntities1();
        public ActionResult Index()
        {
            var values = db.TblProfile.ToList();
            return View(values);
        }
        public ActionResult ProfileDetails()
        {
            var values = db.TblProfile.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddProfile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProfile(TblProfile p)
        {
            var values = db.TblProfile.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProfile(int id)
        {
            var values=db.TblProfile.Find(id);
            db.TblProfile.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProfile(int id)
        {
            var values = db.TblProfile.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateProfile(TblProfile p)
        {
            var values = db.TblProfile.Find(p.ProfileID);
            values.ProfileTitle = p.ProfileTitle;
            values.ProfileDescription = p.ProfileDescription;
            values.Name = p.Name;
            values.Mail = p.Mail;
            values.Address = p.Address;
            values.Phone = p.Phone;
            values.SocialMedia1 = p.SocialMedia1;
            values.SocialMedia2 = p.SocialMedia2;
            values.SocialMedia3 = p.SocialMedia3;
            values.SocialMedia4 = p.SocialMedia4;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}