using System;

namespace PropertyFinder.Data.ViewModel
{
    public class MessageViewModel : ViewModelBase
    {
        public string TenantEmail { get; set; }
        public string TenantName { get; set; }
        public int TenantId { get; set; }

        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }

        public DateTime Date { get; set; }

        public string Message { get; set; }

        public bool IsOwner { get; set; }
    }
}