using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OutOfSpace.API.Data;

namespace OutOfSpace.API.Controllers
{
    public class HomeController : Controller
    {
        private DataContext context = new DataContext();
        public ActionResult Index()
        {
            return View();
        }
    }
}
