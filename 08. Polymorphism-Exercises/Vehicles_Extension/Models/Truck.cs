namespace Vehicles_Extension.Models
{
    internal class Truck : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCREMENT = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption 
        { 
            get => base.FuelConsumption; 
            protected set => base.FuelConsumption = value + FUEL_CONSUMPTION_INCREMENT; 
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters * 0.95);
        }
    }
}
