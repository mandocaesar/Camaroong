using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using DeCamaroong.Domain;
using DeCamaroong.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace DeCamaroong.Controllers
{
    public class WsMailController : ApiController
    {
        private ApplicationUserManager _userManager;
        private DBContext db = new DBContext();
        //HttpContext httpContext = new HttpContext(new Http

        public RoleManager<IdentityRole> RoleManager { get; set; }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        [HttpGet]
        [Authorize]
        public List<Mail> GetAllMail()
        {
            return db.Mails.OrderBy(e=>e.createdDate).ToList();
        }

        [HttpGet]
        [Authorize]
        public int GetUnreadMail()
        {
            return db.Mails.Count(e => e.isNew == true);
        }

        [HttpGet]
        [Authorize]
        public HttpResponseMessage GetMail(int id)
        {
            try
            {
                var mail = db.Mails.First(e => e.ID == id);
                mail.isNew = false;
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.Accepted, mail);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            //return mail;
        }

        [HttpPost]
        public HttpResponseMessage PostMail(Mail mail)
        {
            try
            {
                mail.createdDate = DateTime.Now;
                mail.isNew = true;
                db.Mails.Add(mail);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);   
                throw;
            }
        }
    }
}