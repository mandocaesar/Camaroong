using DeCamaroong.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using DeCamaroong.Domain;

namespace DeCamaroong.Controllers
{

    public class WS_BlogController : ApiController
    {
        private DBContext db = new DBContext();
        //HttpContext httpContext = new HttpContext(new Http

        public RoleManager<IdentityRole> RoleManager { get; private set; }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpGet]
        public List<BlogItem> GetUserBlogItems()
        {
            return db.BlogItems.ToList();
        }

        [HttpGet]
        public List<BlogItem> GetUserBlogItemsHome()
        {
            return db.BlogItems.OrderBy(e => e.date).Take(4).ToList();
        }

        [HttpPost]
        public BlogItem GetUserBlogItem(int ID)
        {
            return db.BlogItems.FirstOrDefault(e => e.ID == ID);
        }

        [HttpPost]
        [Authorize]
        public HttpResponseMessage PostBlogItem(BlogItemViewModel item)
        {
            var modelStateErrors = ModelState.Values.ToList();

            List<string> errors = (from s in modelStateErrors from e in s.Errors where e.ErrorMessage != null 
                                       && e.ErrorMessage.Trim() != "" select e.ErrorMessage).ToList();

            if (errors.Count == 0)
            {
                try
                {
                    string userId = Request.GetOwinContext().Authentication.User.Identity.GetUserId();

                    var currentUser = UserManager.FindById(userId);
                    currentUser.BlogItems.Add(new BlogItem()
                    {
                        Content = item.Content,
                        Title = item.Title,
                        date = DateTime.Now
                    });

                    UserManager.Update(currentUser);
                    return Request.CreateResponse(HttpStatusCode.Accepted);
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                return Request.CreateResponse<List<string>>(HttpStatusCode.BadRequest, errors);
            }

        }

        [HttpPost]
        [Authorize]
        public HttpResponseMessage UpdatePostItem(BlogItem item)
        {
            try
            {
                var it = db.BlogItems.FirstOrDefault(t => t.ID == item.ID);
                if (it != null)
                {
                    it.Content = item.Content;
                    it.Title = item.Title;
                    db.SaveChanges();
                }

                return Request.CreateResponse(HttpStatusCode.Accepted);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Authorize]
        public HttpResponseMessage DeleteBlogItem(int id)
        {
            try
            {
                var item = db.BlogItems.FirstOrDefault(t => t.ID == id);
                if (item != null)
                {
                    db.BlogItems.Remove(item);
                    db.SaveChangesAsync();
                }
                return Request.CreateResponse(HttpStatusCode.Accepted);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }




    }
}
