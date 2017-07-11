using System;

namespace DynamicQueries.Models
{
    public class Source : AuditableEntity, INomenclatureEntity
    {
        public int SourceId { get; set; }

        public string Name { get; set; }

        public string GetNomenclatureId()
        {
            return this.SourceId.ToString();
        }

        public string GetNomenclatureName()
        {
            return this.Name;
        }
    }
}
