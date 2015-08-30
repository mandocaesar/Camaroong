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
        public string Title { get; set; }
        public string Content { get; set; }
    }
}