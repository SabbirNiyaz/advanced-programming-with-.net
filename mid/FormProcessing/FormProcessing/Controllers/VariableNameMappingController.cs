using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormProcessing.Controllers
{
    public class VariableNameMappingController : Controller
    {
        // GET: VariableNameMapping
        public ActionResult VariableNameMapping(string Name, string Email)
        {   
            ViewBag.Name = Name;
            ViewBag.Email = Email;

            return View();
        }
    }
}