using PropertyFinder.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace PropertyFinder.Data
{
    public class User: ModelBase
    {
        [Required]
        [MaxLength(255)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(255)]
        public string Lastname { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }
        
        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
