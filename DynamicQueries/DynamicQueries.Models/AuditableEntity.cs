using System;

namespace DynamicQueries.Models
{
    public class AuditableEntity : IAuditableEntity
    {
        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool Deleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string DeletedBy { get; set; }
    }
}
