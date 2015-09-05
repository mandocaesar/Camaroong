using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace DeCamaroong.Domain
{
    public class PropertyBuilding
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string LandSquare { get; set; }
        public string BuildingSquare { get; set; }
        public int BathRoom { get; set; }
        public int BedRoom { get; set; }
        public string Content { get; set; }
        public decimal Price { get; set; }
        public DateTime PostDate { get; set; }


        public List<BuildingImage> Images { get; set; }
    }
}