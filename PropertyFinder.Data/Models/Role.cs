using PropertyFinder.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace PropertyFinder.Data
{
    public class Role : ModelBase
    {
        [Required]
        [MaxLength(255)]
       public string Name { get; set; }
    }
}
