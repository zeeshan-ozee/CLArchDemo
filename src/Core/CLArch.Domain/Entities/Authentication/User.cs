using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Domain.Common;

namespace CLArch.Domain.Entities.Authentication
{
    public class User : BaseEntity<Guid>
    {
        //public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

    }
}