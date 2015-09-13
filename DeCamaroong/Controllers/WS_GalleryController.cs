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
        public HttpResponseMessage Add(List<Gallery> items)
        {
            try
            {
                using (var db = new DBContext())
                {
                    db.Galleries.AddRange(items);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Accepted);
                }

            }
            catch (Exception)
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
