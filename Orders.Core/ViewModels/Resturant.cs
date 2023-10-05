using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.ViewModels
{
    public class ResturantViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LogUrl { get; set; }
        [Required]
        public string Phone { get; set; }
        public double? Latitude { get; set; }
        public double? Logittude { get; set; }
        public string Address { get; set; }

    }
}
