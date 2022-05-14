using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.Cars
{
    public class Car : Vehicle
    {
        private const double DEFULT_FUEL_CONSUMPTION = 3;
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
            
        }

        public override double FuelConsumption 
            => DEFULT_FUEL_CONSUMPTION;
    }
}
