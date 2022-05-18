using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance_Demo
{
    // Superclass - Base class or Parent class
    public class MotorVehicle
    {
        public int currTransmission;
        private int maxTransmission = 6;

        public virtual void Move()
        {
            Console.WriteLine("Base class move");
            // TODO:
        }

        public void UpTransmission()
        {
            currTransmission++;
            if (currTransmission > maxTransmission)
            {
                currTransmission = maxTransmission;
            }
        }

        public void DownTransmission()
        {
            currTransmission--;
            if (currTransmission < 0)
            {
                currTransmission = 0;
            }
        }
    }
}
