using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DeCamaroong.Domain;
using DeCamaroong.Models;

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
        public HttpResponseMessage Add(Gallery item)
        {
            try
            {
                using (var db = new DBContext())
                {
                    db.Galleries.Add(item);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Accepted);
                }

            }
            catch (Exception)
            {
              return  Request.CreateResponse(HttpStatusCode.BadRequest);
            }
          
        }

        [HttpPost]
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
