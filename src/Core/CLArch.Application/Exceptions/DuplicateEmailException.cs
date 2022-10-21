using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLArch.Application.Exceptions
{

    public class DuplicateEmailException : System.Exception
    {
        public DuplicateEmailException() { }
        public DuplicateEmailException(string message) : base(message) { }
        public DuplicateEmailException(string message, System.Exception inner) : base(message, inner) { }
        public DuplicateEmailException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public class WrongCredentialsException : System.Exception
    {
        public WrongCredentialsException() { }
        public WrongCredentialsException(string message) : base(message) { }
        public WrongCredentialsException(string message, System.Exception inner) : base(message, inner) { }
        public WrongCredentialsException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}