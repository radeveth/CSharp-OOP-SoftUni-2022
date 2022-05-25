namespace Vehicles_Extension.Models
{
    internal class Bus : Vehicle
    {
        private const double FUEL_CONSUMPTION_WITH_PEOPLE_IN_BUS_ICREMENT = 1.4; 

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            protected set
            {
                if (IsEmpty)
                {
                    base.FuelConsumption = value;
                }
                else if (!IsEmpty)
                {
                    base.FuelConsumption = value + FUEL_CONSUMPTION_WITH_PEOPLE_IN_BUS_ICREMENT;
                }
            }
        }
    }
}