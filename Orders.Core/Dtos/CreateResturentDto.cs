﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.Dtos
{
    public class CreateResturentDto
    {
        [Required]
        public string Name { get; set; }
        public string LogUrl { get; set; }
        [Required]
        public string Phone { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Logittude { get; set; }
        public string Address { get; set; }


    }
}
