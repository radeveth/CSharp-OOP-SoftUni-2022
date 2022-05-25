namespace Vehicles_Extension
{
    internal static class ExceptionMessages
    {
        public static string InvalidFuelQuantityInput =
            "Invalid fuel quantity! Fuel quantity cannot be smaller than zero!";

        public static string InvalidFuelConsumptionInput =
            "Invalid fuel consumption! Fuel Consumption cannot be zero or smaller than zero!";

        public static string InvalidTankCapacityInput =
            "Invalid tank capacity! Tank capacity cannot be zero or smaller than zero!";

        public static string NegativeLitersInRefuelOperation =
            "Fuel must be a positive number";

        public static string InvalidRefuelOperation =
            "Cannot fit {0} fuel in the tank";
    }
}
