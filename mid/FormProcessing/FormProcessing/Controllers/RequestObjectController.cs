using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormProcessing.Controllers
{
    public class RequestObjectController : Controller
    {
        // GET: RequestObject
        [HttpGet]
        public ActionResult RequestObject()
        {
            return View(); // just show the form
        }

        // POST: RequestObject
        [HttpPost]
        public ActionResult RequestObject(FormCollection form)
        {
            string Name = form["Name"];
            string Email = form["Email"];

            ViewBag.Name = Name;  // use consistent casing
            ViewBag.Email = Email;

            return View();
        }
    }

}