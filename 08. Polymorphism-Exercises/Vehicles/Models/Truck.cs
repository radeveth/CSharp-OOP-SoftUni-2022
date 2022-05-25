namespace Vehicles.Models
{
    internal class Truck : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCREMENT = 1.6;
        private const double GIVEN_FUEL_INCREMENT = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption 
        { 
            get => base.FuelConsumption; 
            protected set => base.FuelConsumption = value + FUEL_CONSUMPTION_INCREMENT; 
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters * GIVEN_FUEL_INCREMENT);
        }
    }
}
