using System;
using System.Linq;

using Vehicles.Models;

namespace Vehicles.Core
{
    internal class Engine : IEngine
    {
        private Vehicle car;
        private Vehicle truck;


        public void Run()
        {
            car = Input();
            truck = Input();

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
                string action = cmdArgs[0];
                string vehicleType = cmdArgs[1];
                double args = double.Parse(cmdArgs[2]);

                if (action == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        Console.WriteLine(car.Drive(args));
                    }
                    else if (vehicleType == "Truck")
                    {
                        Console.WriteLine(truck.Drive(args));
                    }
                }
                else if (action == "Refuel")
                {
                    if (vehicleType == "Car")
                    {
                        car.Refuel(args);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(args);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private Vehicle Input()
        {
            string[] inputArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string type = inputArgs[0];
            double fuelQuantity = double.Parse(inputArgs[1]);
            double fuelConsumption = double.Parse(inputArgs[2]);

            if (type == "Car")
            {
                return new Car(fuelQuantity, fuelConsumption);
            }
            else if (type == "Truck")
            {
                return new Truck(fuelQuantity, fuelConsumption);
            }

            throw new InvalidOperationException("Invalid operation!");
        }
    }
}
