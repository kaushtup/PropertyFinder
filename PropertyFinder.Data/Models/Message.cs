using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyFinder.Data.Models
{
    public class Message : ModelBase
    {
        public int TenantId { get; set; }

        public int OwnerId { get; set; }

        [ForeignKey("TenantId")]
        public virtual User User { get; set; }

        [ForeignKey("OwnerId")]
        public virtual User Users { get; set; }

        [Required]
        public string Messages { get; set; }

        public DateTime date { get; set; }

        //to check for notifications
        public bool IsChecked { get; set; }

        //if yes, owner sent message to tenant else different
        public bool IsOwner { get; set; }
    }
}
