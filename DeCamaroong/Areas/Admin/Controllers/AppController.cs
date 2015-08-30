using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeCamaroong.Areas.Admin.Controllers
{
    public class AdminAppController : Controller
    {
        public ActionResult SignIn()
        {
            return PartialView();
        }
        // GET: Admin/App
        [Authorize]
        public ActionResult BlogManager()
        {
            return PartialView();
        }
    }
}