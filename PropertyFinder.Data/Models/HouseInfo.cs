using System;
using System.ComponentModel.DataAnnotations;

namespace PropertyFinder.Data.Models
{
    public class HouseInfo: ModelBase
    {
        [Required(ErrorMessage = "Please enter title")]
        [Display(Name = "First Name")]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public HouseType HouseType { get; set; }

        [Required(ErrorMessage = "Please enter house type")]
        [Display(Name = "House Type")]
        public int HouseTypeId { get; set; }

        public AddressInfo AddressInfo { get; set; }

        [Required(ErrorMessage = "Please enter address")]
        [Display(Name = "Address")]
        public int AddressInfoId { get; set; }

        [Required(ErrorMessage = "Please enter cost")]
        [Display(Name = "Cost")]
        public int Cost { get; set; }

        [Required(ErrorMessage = "Please enter number of bedroom")]
        [Display(Name = "Number of Bedroom")]
        public int NumberOfBedroom { get; set; }

        [Required(ErrorMessage = "Please enter available date")]
        [Display(Name = "Available Date")]
        public DateTime AvailableDate { get; set; }

        [Required]
        public bool IsRent { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

       
    }
}
