using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DeCamaroong.Domain;
using DeCamaroong.Models;
using Microsoft.Ajax.Utilities;

namespace DeCamaroong.Controllers
{
    public class WsBuildingController : ApiController
    {
        private readonly DBContext db = new DBContext();

        [HttpGet]
        [Authorize]
        public HttpResponseMessage GetAllBuilding()
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = true;
                db.Configuration.LazyLoadingEnabled = true;
                var result = db.Buildings.Include(p=>p.Images).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetBuilding(int Id)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = true;
                db.Configuration.LazyLoadingEnabled = true;
                var result = db.Buildings.Include(p => p.Images).First(e => e.ID == Id);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        


        [HttpGet]
        public HttpResponseMessage GetTopBuilding(int? number)
        {
            try
            {
                var i = number != 0 && number != null ? number : 5;

                var count = (int) i;
                db.Configuration.ProxyCreationEnabled = true;
                db.Configuration.LazyLoadingEnabled = true;
                var result = db.Buildings.Include(p => p.Images).Take(count).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Authorize]
        public HttpResponseMessage DeleteBuilding(int id)
        {
            try
            {
                
                db.Buildings.Remove(db.Buildings.Include(p => p.Images).First(e => e.ID == id));
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Authorize]
        public HttpResponseMessage DeleteImage(string idx)
        {
            try
            {
                var value = idx.Split('-');
                int id = int.Parse(value[0].ToString());
                int imageIdx = int.Parse(value[1].ToString());
                db.Configuration.ProxyCreationEnabled = true;
                db.Configuration.LazyLoadingEnabled = true;

                db.Buildings.Include(p=>p.Images).First(e => e.ID == id).Images.RemoveAt(imageIdx);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Authorize]
        public HttpResponseMessage PostBuilding(PropertyBuilding building)
        {
            try
            {
                building.PostDate = DateTime.Now;
                foreach (var item in building.Images)
                {
                    item.CreatedDate = DateTime.Now;
                    item.MainImage = false;
                }
                db.Buildings.Add(building);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Authorize]
        public HttpResponseMessage UpdateBuilding(PropertyBuilding building)
        {
            try
            {
                var count = db.Buildings.Where(e => e.ID == building.ID).Count();
                var item = building;
                if (count != 0)
                {
                    item = db.Buildings.First(e => e.ID == building.ID);
                    item.BathRoom = building.BathRoom;
                    item.BedRoom = building.BedRoom;
                    item.BuildingSquare = building.BuildingSquare;
                    item.Content = building.Content;
                    item.LandSquare = building.LandSquare;
                    item.Price = building.Price;
                    item.Title = building.Title;
                    item.Images = building.Images; 
                }
                    db.Buildings.AddOrUpdate(item);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
               
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }
        }
    }
}