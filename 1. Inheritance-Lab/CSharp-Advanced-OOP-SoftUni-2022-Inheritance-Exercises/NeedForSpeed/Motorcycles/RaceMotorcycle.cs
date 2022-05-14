using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.Motorcycles
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DEFULT_FUEL_CONSUMPTION = 8;
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }

        public override double FuelConsumption 
            => DEFULT_FUEL_CONSUMPTION;
    }
}
