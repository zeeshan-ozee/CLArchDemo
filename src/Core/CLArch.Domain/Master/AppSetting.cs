using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CLArch.Domain.Common;

namespace CLArch.Domain.Master
{
    public class AppSetting : BaseEntity<int>
    {
        public string ReferenceKey { get; set; }
        public string Value { get; set; }
        public string? Description { get; set; }
        public string Type { get; set; } = string.Empty;

    }
}