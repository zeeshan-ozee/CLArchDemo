using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLArch.Application.Exceptions
{

    public class DuplicateEmailException : System.Exception
    {
        public const string ExMessage = "User already exists with same email address.";
        public DuplicateEmailException() { }
        public DuplicateEmailException(string message) : base(message) { }
        public DuplicateEmailException(string message, System.Exception inner) : base(message, inner) { }
        public DuplicateEmailException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}