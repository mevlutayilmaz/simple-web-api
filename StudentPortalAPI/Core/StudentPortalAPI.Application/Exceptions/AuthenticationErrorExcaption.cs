using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Application.Exceptions
{
    public class AuthenticationErrorExcaption : Exception
    {
        public AuthenticationErrorExcaption() : base("Authentication error!")
        {
        }

        public AuthenticationErrorExcaption(string? message) : base(message)
        {
        }

        public AuthenticationErrorExcaption(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
