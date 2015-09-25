using System;

namespace DeCamaroong.Models
{
    public class GalleryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public dynamic File { get; set; }
    }
}