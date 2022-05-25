using System;
using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    internal abstract class Vehicle : IDriveable, IRefuelable
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }


        public double FuelQuantity { get; protected set; }
        public virtual double FuelConsumption { get; protected set; }

        public string Drive(double distance)
        {
            double neededFuelQuantity = distance * this.FuelConsumption;
            Math.Round(neededFuelQuantity);

            if (neededFuelQuantity > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= neededFuelQuantity;
            return $"{this.GetType().Name} travelled 9 km";
        }
        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
