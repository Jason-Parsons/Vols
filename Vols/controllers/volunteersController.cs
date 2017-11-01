using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vols.Controllers
{
    public class volunteersController : Controller
    {
        // GET: volunteers
        public ActionResult Index()
        {
            return View();
        }
    }
}