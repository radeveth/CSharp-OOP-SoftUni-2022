using System;
using Vehicles_Extension.Models.Contracts;

namespace Vehicles_Extension.Models
{
    internal abstract class Vehicle : IVehicleable
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;


        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.tankCapacity = tankCapacity;
        }


        public double FuelQuantity 
        { 
            get => this.fuelQuantity;
            protected set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException
                        (String.Format(ExceptionMessages.InvalidFuelQuantityInput));
                }
                this.fuelQuantity = value;
            }
        }

        public virtual double FuelConsumption 
        {
            get => this.fuelConsumption;
            protected set
            {
                if (value <=  0)
                {
                    throw new InvalidOperationException
                        (String.Format(ExceptionMessages.InvalidFuelConsumptionInput));
                }

                this.fuelConsumption = value;
            }
        }

        public double TankCapacity 
        {
            get => this.tankCapacity;
            private set
            {
                if (value <= 0)
                {
                    //throw new InvalidOperationException
                    //    (String.Format(ExceptionMessages.InvalidTankCapacityInput));
                    Console.WriteLine(String.Format(ExceptionMessages.InvalidTankCapacityInput));
                }
                this.tankCapacity = value;
            }
        }

        public bool IsEmpty { get; set; } = true;

        public virtual string Drive(double distance)
        {
            double neededFuelQuantity = distance * this.FuelConsumption;

            if (neededFuelQuantity > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= neededFuelQuantity;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            //if (liters <= 0)
            //{
            //    throw new InvalidOperationException
            //        (String.Format(ExceptionMessages.NegativeLitersInRefuelOperation));
            //}
            if (liters <= 0)
            {
                Console.WriteLine(String.Format(ExceptionMessages.NegativeLitersInRefuelOperation));
            }

            double aviableSpaceInTank = this.TankCapacity - this.FuelQuantity;
            //if (liters > aviableSpaceInTank)
            //{
            //    throw new InvalidOperationException
            //        (String.Format(ExceptionMessages.InvalidRefuelOperation, liters));
            //}
            if (liters > aviableSpaceInTank)
            {
                Console.WriteLine(String.Format(ExceptionMessages.InvalidRefuelOperation, liters));
            }

            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
