using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS.Exceptions
{
    public class NoInternetConnectionException : Exception
    {
        public NoInternetConnectionException() : base()
        {}

        public NoInternetConnectionException(string message) : base(message)
        {}
    }
}
