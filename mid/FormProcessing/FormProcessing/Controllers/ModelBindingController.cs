using FormProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormProcessing.Controllers
{
    public class ModelBindingController : Controller
    {
        // GET: ModelBinding
        [HttpGet]
        public ActionResult ModelBinding()
        {
            User user = new User(); // empty model
            return View(user);
        }

        // POST: ModelBinding
        [HttpPost]
        public ActionResult ModelBinding(User user)
        {
            ViewBag.Name = user.Name;
            ViewBag.Email = user.Email;

            return View(user); // pass the model back to view
        }

    }
}