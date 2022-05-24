using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public RandomList()
        {
            random = new Random();
        }

        private Random random;
        public string RandomString()
        { 
            int index = random.Next(0, this.Count);
            string element = this[index];
            this.RemoveAt(index);
            return element;
        }
    }
}
