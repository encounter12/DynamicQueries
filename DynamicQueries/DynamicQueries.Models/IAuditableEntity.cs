using System;

namespace DynamicQueries.Models
{
    public interface IAuditableEntity
    {
        string CreatedBy { get; set; }

        DateTime? CreatedOn { get; set; }

        string ModifiedBy { get; set; }

        DateTime? ModifiedOn { get; set; }

        bool Deleted { get; set; }

        DateTime? DeletedOn { get; set; }

        string DeletedBy { get; set; }
    }
}
