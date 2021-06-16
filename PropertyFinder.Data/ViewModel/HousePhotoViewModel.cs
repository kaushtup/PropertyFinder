using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyFinder.Data.ViewModel
{
    public class HousePhotoViewModel : ViewModelBase
    {
        public string HouseInfoId { get; set; }

        public int PhotoId { get; set; }

        public string PhotoName { get; set; }
    }
}
