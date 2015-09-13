using System;
using System.ComponentModel.DataAnnotations;

namespace DeCamaroong.Domain
{
    public class Gallery
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public Gallery()
        {
            CreatedDate = DateTime.Now;
        }
    }
}