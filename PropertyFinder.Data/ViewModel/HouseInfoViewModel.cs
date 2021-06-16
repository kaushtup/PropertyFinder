using Microsoft.AspNetCore.Http;
using PropertyFinder.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PropertyFinder.Data.ViewModel
{
    public class HouseInfoViewModel : ViewModelBase
    {
        [Required(ErrorMessage = "Please enter title")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public HouseType HouseType { get; set; }

        //[Required(ErrorMessage = "Please enter house type")]
        [Display(Name = "House Type")]
        public int HouseTypeId { get; set; }

        [Required(ErrorMessage = "Please select photo")]
        public List<IFormFile> Photo { get; set; }

        public List<string> PhotoInfo { get; set; }

        public AddressInfo AddressInfo { get; set; }

        //[Required(ErrorMessage = "Please enter address")]
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
        
        public bool IsRent { get; set; }

        public int userId { get; set; }
    }
}
