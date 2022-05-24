using System;
using System.Linq;
using Telephony.Exceptions;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] urls = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();



            foreach (string number in numbers)
            {
                try
                {
                    if (number.Length == 10)
                    {
                        Smartphone smartphone = new Smartphone();
                        Console.WriteLine(smartphone.Calling(number));
                    }
                    else if (number.Length == 7)
                    {
                        StationaryPhone stationaryPhone = new StationaryPhone();
                        Console.WriteLine(stationaryPhone.Calling(number));
                    }
                    else
                    {
                        throw new InvalidNumberException();
                    }
                }
                catch (InvalidNumberException exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }

            foreach (string url in urls)
            {
                Smartphone smartphone = new Smartphone();
                Console.WriteLine(smartphone.Browsing(url));
            }
        }
    }
}
