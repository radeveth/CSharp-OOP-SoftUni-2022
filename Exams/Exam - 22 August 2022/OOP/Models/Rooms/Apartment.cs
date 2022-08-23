namespace BookingApp.Models.Rooms
{
    using System;

    public class Apartment : Room
    {
        private const int Bed_Capacity = 6;

        public Apartment() 
            : base(Bed_Capacity)
        {
        }
    }
}
