namespace BookingApp.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Repositories.Contracts;

    public class RoomRepository : IRepository<IRoom>
    {
        private readonly List<IRoom> rooms;

        public RoomRepository()
        {
            this.rooms = new List<IRoom>();
        }

        public IReadOnlyCollection<IRoom> All() 
            => this.rooms;

        public void AddNew(IRoom model)
            => this.rooms.Add(model);

        public IRoom Select(string roomTypeName)
            => this.rooms.FirstOrDefault(r => r.GetType().Name == roomTypeName);
    }
}
