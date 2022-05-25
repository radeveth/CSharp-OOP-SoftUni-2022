namespace Vehicles_Extension.Models.Contracts
{
    internal interface IVehicleable
    {
        public double FuelQuantity { get; }
        public double FuelConsumption { get; }
        public double TankCapacity { get; }
        public bool IsEmpty { get; set; }

        public string Drive(double distance);
        public void Refuel(double liters);

    }
}
