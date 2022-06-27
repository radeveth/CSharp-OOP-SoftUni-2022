using System;

namespace Summator
{
    public class Sum
    {
        public long SumOfDigits(long num)
        {
            long sum = 0;
            num = Math.Abs(num);
            while (num != 0)
            {
                sum += num % 10;
                num /= 10;
            }

            return sum;
        }
    }
}
