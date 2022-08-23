namespace BookingApp.Models.Rooms
{
    using System;

    public class DoubleBed : Room
    {
        private const int Bed_Capacity = 2; 

        public DoubleBed() 
            : base(Bed_Capacity)
        {
        }
    }
}
