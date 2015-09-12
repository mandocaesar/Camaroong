using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeCamaroong.Controllers
{
    /// <summary>
    /// Create an ActionResult and PartialView for each angular partial view you want to attatch to a route in the angular app.js file.
    /// </summary>
    public class AppController : Controller
    {
        public ActionResult Register()
        {
            return PartialView();
        }
        public ActionResult SignIn()
        {
            return PartialView();
        }
        public ActionResult Home()
        {
            return PartialView();
        }

        public ActionResult ViewNews()
        {
            return PartialView();
        }

        public ActionResult ViewBuilding()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult BlogManager()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult Mail()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult Building()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult AddEditBuilding()
        {
            return PartialView();
        }

        public ActionResult ManageGallery()
        {
            return PartialView();
        }

        public ActionResult Gallery()
        {
            return PartialView();
        }

    }
}