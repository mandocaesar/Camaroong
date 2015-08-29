using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeCamaroong.Models
{
    public class BlogItemViewModel
    {
        [Required(ErrorMessage = "The Task Field is Required.")]

        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }
    }
}