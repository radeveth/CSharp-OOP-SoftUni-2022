using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Box_Data
{
    internal class Engine
    {
        private Box box;

        public void Run()
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            box = new Box(length, width, height);
            Console.WriteLine(box);
        }
    }
}
