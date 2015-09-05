using System;
using System.ComponentModel.DataAnnotations;

namespace DeCamaroong.Domain
{
    public class BuildingImage
    {
        [Key]
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public bool MainImage { get; set; }
    }
}