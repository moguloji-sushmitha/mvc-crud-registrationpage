using RegistrationPage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationPage.Controllers
{
    public class HomeController : Controller
    {
      ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read()
        {
            var list = db.Registrations.ToList();
            return View(list);
        }
        public ActionResult Edit(int id)
        {
            var editobj = db.Registrations.FirstOrDefault(a=>a.Id == id);
            return View(editobj);
        }
        [HttpPost]
        public ActionResult Edit(Registration reg)
        {
            var data = db.Registrations.FirstOrDefault(a=>a.Id==reg.Id);
            if(data!=null)
            {
                data.Name=reg.Name;
                data.Email = reg.Email;
                db.SaveChanges();
            }
            return RedirectToAction("Create");
        }
        public ActionResult Create()
        {
            var registration = db.Registrations.ToList();
            return View(registration);
        
        }
        [HttpPost]
        public ActionResult Create(Registration r)
        {
            Registration data = new Registration();
            data.Id = r.Id;
            data.Name = r.Name;
            data.Email = r.Email;
            db.Registrations.Add(data);
            db.SaveChanges();
            return RedirectToAction("Create");
        }
        public ActionResult Delete(int id)
        {
            var obj=db.Registrations.FirstOrDefault(x => x.Id == id);
            if (obj != null) 
            {
                db.Registrations.Remove(obj);
                db.SaveChanges();   
            }
            return RedirectToAction("Index");
        }
        
    }
}