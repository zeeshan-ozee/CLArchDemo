using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLArch.Domain.Common
{
    public interface IAuditableEntity
    {
        bool IsDeleted { get; set; }
        DateTime CreatedOn { get; set; }

        //Author
        string CreatedBy { get; set; }


        DateTime ModifiedOn { get; set; }

        //Editor
        string ModifieddBy { get; set; }
    }
}