using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance_Demo
{
    // Subclass - Child class
    public class Truck : MotorVehicle
    {
        private int capacity = 6;
        private Stack<string> items;

        void Load(string item)
        {
            if (items.Count < capacity)
            {
                items.Push(item);
            }
        }

        string UnLoad()
        {
            if (items.Count != 0)
            {
                return items.Pop();
            }
            return "In the truck have zero items.";
        }
    }
}
