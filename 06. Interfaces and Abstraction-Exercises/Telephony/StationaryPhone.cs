using System.Linq;
using Telephony.Exceptions;

namespace Telephony
{
    public class StationaryPhone : ICalling
    {

        public string Calling(string number)
        {
            if (!number.Any(ch => char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }

            return $"Dialing... {number}";
        }
    }
}
