using System;
using System.ComponentModel.DataAnnotations;

namespace PropertyFinder.Data.Models
{
    public class HouseType : ModelBase
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
