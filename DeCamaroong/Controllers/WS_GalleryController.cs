using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DeCamaroong.Domain;
using DeCamaroong.Models;
using WebGrease;

namespace DeCamaroong.Controllers
{
    public class WsGalleryController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetGallery()
        {
            try
            {
                using (var db = new DBContext())
                {
                    var result = db.Galleries.ToList();
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Accepted, result);
                }

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Authorize]
        public HttpResponseMessage Add(List<Gallery> items)
        {
            try
            {
                foreach (var item in items)
                {
                    List<string> content = item.Content.Split(',').ToList();
                    var bytes = Convert.FromBase64String(content[1]);
                    string mappath = HttpContext.Current.Server.MapPath("~/Assets/img/gallery/");
                    string filepath = String.Format(mappath + "{0}", item.Name);
                    using (var imageFile = new FileStream(filepath, FileMode.Create))
                    {
                        imageFile.Write(bytes, 0, bytes.Length);
                        imageFile.Flush();
                    }

                    item.Content = String.Format("Assets/img/gallery/{0}", item.Name);
                }
                using (var db = new DBContext())
                {
                    db.Galleries.AddRange(items);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Accepted);
                }

            }
            catch (Exception ex)
            {
              return  Request.CreateResponse(HttpStatusCode.BadRequest);
            }
          
        }

        [HttpGet]
        [Authorize]
        public HttpResponseMessage Delete(int ID)
        {
            try
            {
                using (var db = new DBContext())
                {
                    db.Galleries.Remove(db.Galleries.First(g => g.ID == ID));
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Accepted);
                }

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
