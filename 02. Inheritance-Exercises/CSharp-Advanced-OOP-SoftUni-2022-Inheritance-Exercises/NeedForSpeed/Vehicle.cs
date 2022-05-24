using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        const double DEFULT_FUEL_CONSUMPTION = 1.25;

        private double fuel;
        private int horsePower;


        public virtual double FuelConsumption
            => DEFULT_FUEL_CONSUMPTION;

        public double Fuel
        {
            get
            {
                return fuel;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel cannot be negative.");
                }
                this.fuel = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return horsePower;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Horse power cannot be negative.");
                }
                this.horsePower = value;
            }
        }

        public virtual void Drive(double kilometers)
        {
            if (this.Fuel - kilometers <= 0)
            {
                Console.WriteLine("The vehicle have not enough fuel for driving.");
            }
            else if (this.Fuel - kilometers > 0)
            { 
                this.Fuel -= kilometers;
            }
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}\nHorse power: {this.HorsePower}\nFuel: {this.Fuel}\nFueal consumption: {this.FuelConsumption}";
        }
    }
}
