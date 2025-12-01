using DotNet.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNet.Controllers
{
    public class StudentController : Controller
    {
        DotNetEntities db = new DotNetEntities();
        // GET: Student
        [HttpGet]
        public ActionResult Registration()
        {
            var d = db.Departments.ToList();
            return View(d);
        }
        [HttpPost]
        public ActionResult Registration(Student s)
        {
            db.Students.Add(s);
            db.SaveChanges();
            TempData["msg"] = "registration Successfull";
            return RedirectToAction("List");
        }
        public ActionResult List() { 
        var d = db.Students.ToList();
            return View(d);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var st = db.Students.Find(id);
            return View(st);
        }
        [HttpPost]
        public ActionResult Delete(Student s)
        {
            var st = db.Students.Find(s.Id);
            db.Students.Remove(st);
            db.SaveChanges();

            TempData["Msg"] = "Student Data Deleted!";
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.Students.Find(id);
            ViewBag.Depts = db.Departments.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            var data = db.Students.Find(s.Id);
            db.Entry(data).CurrentValues.SetValues(s);
            db.SaveChanges();
            TempData["msg"] = "data updated";
            return RedirectToAction("List");
        }


    }
}