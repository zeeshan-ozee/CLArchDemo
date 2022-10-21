using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLArch.Domain.Exceptions
{
    public class UserNotFoundException : System.Exception
    {
        public UserNotFoundException() { }
        public UserNotFoundException(string message) : base(message) { }
        public UserNotFoundException(string message, System.Exception inner) : base(message, inner) { }
        public UserNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}