﻿namespace Vehicles_Extension.Models
{
    internal class Car : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCREMENT = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            protected set => base.FuelConsumption = value + FUEL_CONSUMPTION_INCREMENT;
        }


    }
}
