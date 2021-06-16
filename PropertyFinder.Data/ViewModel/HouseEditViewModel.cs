using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyFinder.Data.ViewModel
{
    public class HouseEditViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public int HouseTypeId { get; set; }

        public int AddressInfoId { get; set; }

        public int Cost { get; set; }

        public int NumberOfBedroom { get; set; }

        public DateTime AvailableDate { get; set; }

        public bool IsRent { get; set; }
    
        public List<PhotoViewModel> Photo { get; set; }
    }
}
