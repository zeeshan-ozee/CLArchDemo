using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Domain.Common;

namespace CLArch.Domain.Entities.Product
{
    public class Category : AuditableEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Desciption { get; set; } = string.Empty;

        public string DisplayOrder { get; set; }

    }
}