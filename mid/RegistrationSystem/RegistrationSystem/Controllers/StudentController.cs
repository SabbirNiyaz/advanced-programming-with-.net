using RegistrationSystem.EF;
using RegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationSystem.Controllers
{
    public class StudentController : Controller
    {
        StudentsEntities db = new StudentsEntities();
        // GET: Student
        [HttpGet]
        public ActionResult Resigtration()
        {
            return View(new RegistrationModel());
        }
        [HttpPost]
        public ActionResult Resigtration(RegistrationModel model)
        {
            db.Students.Add(model);
            return View(model);
        }
    }
}