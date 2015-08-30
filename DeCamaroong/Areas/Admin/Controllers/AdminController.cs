using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeCamaroong.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Main
        public ActionResult AdminHome()
        {
            return View();
        }
    }
}