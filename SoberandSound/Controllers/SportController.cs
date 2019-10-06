using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoberandSound.Controllers
{
    public class SportController : Controller
    {
        // GET: Sport
        public ActionResult SportIndex()
        {
            return View();
        }
    }
}