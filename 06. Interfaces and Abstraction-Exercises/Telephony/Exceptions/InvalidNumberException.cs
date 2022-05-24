using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Exceptions
{
    public class InvalidNumberException : Exception
    {
        private const string MSG_EXC = "Invalid number!";
        public InvalidNumberException()
            : base(MSG_EXC)
        {

        }

        public InvalidNumberException(string message)
            : base(message)
        {

        }
    }
}
