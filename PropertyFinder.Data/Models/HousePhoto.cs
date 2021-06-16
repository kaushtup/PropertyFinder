using System.ComponentModel.DataAnnotations;

namespace PropertyFinder.Data.Models
{
    public class HousePhoto : ModelBase
    {
        public HouseInfo HouseInfo { get; set; }

        [Required]
        public int HouseInfoId { get; set; }

        public Photo Photo { get; set; }

        [Required]
        public int PhotoId { get; set; }
    }
}
