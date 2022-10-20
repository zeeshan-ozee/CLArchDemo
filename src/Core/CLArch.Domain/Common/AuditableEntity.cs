using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLArch.Domain.Common
{
    public class AuditableEntity<T> : BaseEntity<T>, IAuditableEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifieddBy { get; set; }
    }
}