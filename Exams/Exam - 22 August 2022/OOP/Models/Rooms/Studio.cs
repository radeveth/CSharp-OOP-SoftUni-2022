namespace BookingApp.Models.Rooms
{
    using System;

    public class Studio : Room
    {
        private const int Bed_Capacity = 4;

        public Studio() 
            : base(Bed_Capacity)
        {
        }
    }
}
