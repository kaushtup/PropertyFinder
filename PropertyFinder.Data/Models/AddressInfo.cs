using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PropertyFinder.Data.Models
{
    public class AddressInfo : ModelBase
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public double Longitude { get; set; }

        [Required]
        [MaxLength(255)]
        public double Latitude { get; set; }
    }
}
