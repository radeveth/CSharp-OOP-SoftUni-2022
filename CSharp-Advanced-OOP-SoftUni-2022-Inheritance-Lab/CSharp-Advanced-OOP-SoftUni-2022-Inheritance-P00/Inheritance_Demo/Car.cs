using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance_Demo
{
    // Subclass - Child class
    public class Car : MotorVehicle
    {
        public override void Move()
        {
            Console.WriteLine("Move all 4 tires...");
        }

        void OpenDoor()
        {
            if (currTransmission == 0)
            {
                // TODO:
            }
        }
    }
}
