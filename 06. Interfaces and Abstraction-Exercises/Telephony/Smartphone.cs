using System.Linq;
using Telephony.Exceptions;

namespace Telephony
{
    public class Smartphone : IBrowsing, ICalling
    {
        public string Browsing(string url)
        {
            if (url.Any(ch => char.IsDigit(ch)))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {url}";
        }

        public string Calling(string number)
        {
            if (!number.Any(ch => char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }

            return $"Calling... {number}";
        }
    }
}
