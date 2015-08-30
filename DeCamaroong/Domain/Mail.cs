﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeCamaroong.Domain
{
    public class Mail
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Message { get; set; }
    }
}