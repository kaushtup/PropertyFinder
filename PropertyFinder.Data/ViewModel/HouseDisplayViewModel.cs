using PropertyFinder.Data.Models;
using System;
using System.Collections.Generic;

namespace PropertyFinder.Data.ViewModel
{
    public class HouseDisplayViewModel : ViewModelBase
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public int HouseTypeId { get; set; }

        public string HouseTypeName { get; set; }

        //public List<IFormFile> Photo { get; set; }

        //public List<string> PhotoInfo { get; set; }

        public int AddressInfoId { get; set; }

        public string AddressInfoName { get; set; }
        public int Cost { get; set; }

        public int NumberOfBedroom { get; set; }

        public string AvailableDate { get; set; }

        public bool IsRent { get; set; }

        public List<Photo> Photo { get; set; }
    }
}
