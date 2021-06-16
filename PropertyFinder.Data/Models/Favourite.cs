using System.ComponentModel.DataAnnotations;

namespace PropertyFinder.Data.Models
{
    public class Favourite : ModelBase
    {
        public HouseInfo HouseInfo { get; set; }

        [Required]
        public int HouseInfoId { get; set; }

        public User User { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
