﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.Dtos
{
    public class UpdateUserDto
    {
        public string Id { get; set; }

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Logittude { get; set; }
        public string Address { get; set; }
    }
}
