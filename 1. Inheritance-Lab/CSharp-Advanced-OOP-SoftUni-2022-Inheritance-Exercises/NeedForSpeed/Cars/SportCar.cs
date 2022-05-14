using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.Cars
{
    public class SportCar : Car
    {
        private const double DEFULT_FUEL_CONSUMPTION = 10;

        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }

        public override double FuelConsumption 
            => DEFULT_FUEL_CONSUMPTION;
    }
}
