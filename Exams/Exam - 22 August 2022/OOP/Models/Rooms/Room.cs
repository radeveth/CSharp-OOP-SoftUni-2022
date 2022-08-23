namespace BookingApp.Models.Rooms
{
    using System;
    using BookingApp.Utilities.Messages;
    using BookingApp.Models.Rooms.Contracts;

    public abstract class Room : IRoom
    {
        private int bedCapacity;
        private double pricePerNight;

        public Room(int bedCapacity)
        {
            this.BedCapacity = bedCapacity;
            this.PricePerNight = 0;
        }

        public int BedCapacity
        {
            get => this.bedCapacity;
            set => this.bedCapacity = value;
        }

        public double PricePerNight
        {
            get => this.pricePerNight;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }

                this.pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            this.PricePerNight = price;
        }
    }
}
