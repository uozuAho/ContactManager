using System;

namespace ContactManager.Models
{
    public class BaseAuditEntity
    {
        public DateTime? CreatedUtc { get; set; }
        public string UserCreated { get; set; }
        public DateTime? ModifiedUtc { get; set; }
        public string UserModified { get; set; }
    }
}