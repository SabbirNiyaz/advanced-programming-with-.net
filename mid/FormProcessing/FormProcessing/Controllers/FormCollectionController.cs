using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormProcessing.Controllers
{
    public class FormCollectionController : Controller
    {
        // GET: FormCollection
        public ActionResult FormCollection(FormCollection form)
        {
            string Name = form["Name"];
            string Email = form["Email"];

            ViewBag.Name = Name;
            ViewBag.Email = Email;

            return View();
        }
    }
}