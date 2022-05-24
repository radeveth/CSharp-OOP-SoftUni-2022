using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Exceptions
{
    public class InvalidURLException : Exception
    {
        private const string URL_EXC = "Invalid URL!";
        public InvalidURLException()
            : base(URL_EXC)
        {

        }

        public InvalidURLException(string message)
            : base(message)
        {

        }
    }
}
