using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;

namespace ResumeProject.Controllers
{
    public class SkillController : Controller
    {
        DbResumeEntities1 db = new DbResumeEntities1();
        public ActionResult Index()
        {
            var values = db.TblSkill.ToList();
            return View(values);//içindeki değerlerin görünmesi için values yazdık içine
        }
        [HttpGet] //sayfa sadece yüklenince
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]//kaydet kısmı
        public ActionResult AddSkill(TblSkill p)
        {
            db.TblSkill.Add(p);
            db.SaveChanges();//veri tabanına kaydet bu sadece
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkill(int id)//silme ve güncelleme verilerinde parametre mutlaka id  
        {
           var value= db.TblSkill.Find(id);
            db.TblSkill.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UptadeSkill(int id)
        {
            var value = db.TblSkill.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UptadeSkill(TblSkill p)
        {
            var value = db.TblSkill.Find(p.SkillID);
            value.SkillTitle = p.SkillTitle;
            value.Skillicon = p.Skillicon;
            value.SkillDescription = p.SkillDescription;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}