namespace BookingApp.Models.Hotels
{
    using System;
    using BookingApp.Repositories;
    using BookingApp.Utilities.Messages;
    using BookingApp.Models.Hotels.Contacts;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Repositories.Contracts;
    using BookingApp.Models.Bookings.Contracts;

    public class Hotel : IHotel
    {
        private string fullName;
        private int category;

        private IRepository<IRoom> rooms;
        private IRepository<IBooking> bookings;

        public Hotel(string fullName, int category)
        {
            this.FullName = fullName;
            this.Category = category;

            this.rooms = new RoomRepository();
            this.bookings = new BookingRepository();
        }
        public string FullName
        {
            get => this.fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }

                this.fullName = value;
            }
        }

        public int Category
        {
            get => this.category;
            set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }

                this.category = value;
            }
        }

        public double Turnover => this.TotalPaid();

        public IRepository<IRoom> Rooms 
        {
            get => this.rooms;
            set => this.rooms = value;
        }

        public IRepository<IBooking> Bookings
        {
            get => this.bookings;
            set => this.bookings = value;
        }

        private double TotalPaid()
        {
            double totalPaid = 0;

            foreach (var booking in this.bookings.All())
            {
                totalPaid += booking.ResidenceDuration * booking.Room.PricePerNight;
            }

            return Math.Round(totalPaid, 2);
        }

    }
}
