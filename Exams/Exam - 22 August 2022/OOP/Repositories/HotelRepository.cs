namespace BookingApp.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using BookingApp.Models.Hotels.Contacts;
    using BookingApp.Repositories.Contracts;

    public class HotelRepository : IRepository<IHotel>
    {
        private readonly List<IHotel> hotels;

        public HotelRepository()
        {
            this.hotels = new List<IHotel>();
        }

        public IReadOnlyCollection<IHotel> All()
            => this.hotels;

        public void AddNew(IHotel model)
            => this.hotels.Add(model);

        public IHotel Select(string hotelName)
            => this.hotels.FirstOrDefault(h => h.FullName == hotelName);
    }
}
