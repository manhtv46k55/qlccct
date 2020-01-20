using ccct2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ccct2019.Controllers
{
    public class HomeController : Controller
    {
        [AuthorizeBussiness]
        public ActionResult Index()
        {
            return View();
        }
    }
}