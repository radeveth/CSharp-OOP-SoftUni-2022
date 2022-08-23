namespace BookingApp.Repositories
{
    using System;
    using System.Collections.Generic;
    using BookingApp.Repositories.Contracts;
    using BookingApp.Models.Bookings.Contracts;
    using System.Linq;

    public class BookingRepository : IRepository<IBooking>
    {
        private readonly List<IBooking> bookings;

        public BookingRepository()
        {
            this.bookings = new List<IBooking>();
        }

        public IReadOnlyCollection<IBooking> All()
            => this.bookings;

        public void AddNew(IBooking model)
            => this.bookings.Add(model);

        public IBooking Select(string bookingNumberToString)
            => this.bookings.FirstOrDefault(b => b.BookingNumber.ToString() == bookingNumberToString);
    }
}
