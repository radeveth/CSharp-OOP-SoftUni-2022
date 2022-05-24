using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance_Demo
{
    // Subclass - Child class
    public class Motorbike : MotorVehicle
    {
        public override void Move()
        {
            Console.WriteLine("Move 2 tires...");
        }
    }
}
