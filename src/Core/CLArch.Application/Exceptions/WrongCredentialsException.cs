using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLArch.Application.Exceptions
{

    public class WrongCredentialsException : System.Exception
    {
        public const string ExMessage = "You have provided incorrect credentails.";
        public WrongCredentialsException() { }
        public WrongCredentialsException(string message) : base(message) { }
        public WrongCredentialsException(string message, System.Exception inner) : base(message, inner) { }
        public WrongCredentialsException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}