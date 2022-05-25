using System;
using System.Linq;
using Vehicles_Extension.Models;

namespace Vehicles_Extension.Core
{
    internal class Engine : IEngine
    {
        private Vehicle car;
        private Vehicle truck;
        private Vehicle bus;

        public void Run()
        {
            car = Input();
            truck = Input();
            bus = Input();

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
                string command = cmdArgs[0];
                string vehicleTye = cmdArgs[1];
                double args = double.Parse(cmdArgs[2]);

                if (vehicleTye == "Car")
                {
                    if (command == "Drive")
                    {
                        Console.WriteLine(car.Drive(args));
                    }
                    else if (command == "Refuel")
                    {
                        car.Refuel(args);
                    }
                }
                else if (vehicleTye == "Bus")
                {
                    if (command == "Drive")
                    {
                        bus.IsEmpty = false;
                        Console.WriteLine(bus.Drive(args));
                    }
                    else if (command == "Refuel")
                    {
                        bus.Refuel(args);
                    }
                }
                else if (vehicleTye == "Truck")
                {
                    if (command == "Drive")
                    {
                        Console.WriteLine(truck.Drive(args));
                    }
                    else if (command == "Refuel")
                    {
                        truck.Refuel(args);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }


        public Vehicle Input()
        {
            string[] inputArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string vehicleType = inputArgs[0];
            double fuelQuantoty = double.Parse(inputArgs[1]);
            double fuelConsumption = double.Parse(inputArgs[2]);
            double tankCapacity = double.Parse(inputArgs[3]);

            if (fuelQuantoty > tankCapacity)
            {
                fuelQuantoty = 0;
            }

            if (vehicleType == "Car")
            {
                return new Car(fuelQuantoty, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Bus")
            {
                return new Bus(fuelQuantoty, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Truck")
            {
                return new Truck(fuelQuantoty, fuelConsumption, tankCapacity);
            }
            return null;
        }
    }
}
