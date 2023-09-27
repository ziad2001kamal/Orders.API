﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Data.Models
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string CustomerId { get; set; }
        public User Customer { get; set; }

        public int ResturantId { get; set; }
        public Resturant Resturant { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
