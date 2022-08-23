namespace BookingApp.Core
{
    using System;
    using BookingApp.Repositories;
    using BookingApp.Core.Contracts;
    using System.Collections.Generic;
    using BookingApp.Utilities.Messages;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Models.Hotels.Contacts;
    using System.Linq;
    using BookingApp.Models.Rooms;
    using BookingApp.Models.Bookings.Contracts;
    using BookingApp.Models.Bookings;
    using System.Text;
    using BookingApp.Models.Hotels;

    public class Controller : IController
    {
        private HotelRepository hotelRepository;

        public Controller()
        {
            this.hotelRepository = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = this.hotelRepository.Select(hotelName);

            if (hotel != null)
            {
                return String.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            hotel = new Hotel(hotelName, category);
            this.hotelRepository.AddNew(hotel);

            return String.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = this.hotelRepository.Select(hotelName);

            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            // First way
            //List<IRoom> rooms = (List<IRoom>)hotel.Rooms.All();
            //if (rooms.Any(r => r.GetType().Name == roomTypeName))
            //{
            //    return OutputMessages.RoomTypeAlreadyCreated;
            //}

            // Second way
            //foreach (var r in hotel.Rooms.All())
            //{
            //    if (r.GetType().Name == roomTypeName)
            //    {
            //        return OutputMessages.RoomTypeAlreadyCreated;
            //    }
            //}

            //Third way
            IRoom room = hotel.Rooms.Select(roomTypeName);
            if (room != null)
            {
                return OutputMessages.RoomTypeAlreadyCreated;
            }

            room = roomTypeName switch
            {
                nameof(Apartment) => new Apartment(),
                nameof(DoubleBed) => new DoubleBed(),
                nameof(Studio) => new Studio(),
                _ => throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect),
            };

            hotel.Rooms.AddNew(room);
            return String.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = this.hotelRepository.Select(hotelName);

            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (roomTypeName != nameof(Apartment) && roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Studio))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);
            if (room == null)
            {
                return OutputMessages.RoomTypeNotCreated;
            }

            if (room.PricePerNight != 0)
            {
                throw new InvalidOperationException(ExceptionMessages.CannotResetInitialPrice);
            }

            room.SetPrice(price);

            return String.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            IEnumerable<IHotel> hotels = this.hotelRepository.All().Where(h => h.Category == category).OrderBy(h => h.FullName);

            if (!hotels.Any())
            {
                return String.Format(OutputMessages.CategoryInvalid, category);
            }

            int guestCapacityNeeded = adults + children;
            IHotel targetHotel = hotels.FirstOrDefault(h => h.Rooms.All().Any(r => r.PricePerNight > 0));

            //if (targetHotel == null)
            //{
            //    return OutputMessages.RoomNotAppropriate;
            //}

            // IRoom targetRoom = targetHotel.Rooms.All().FirstOrDefault(r => r.BedCapacity == guestCapacityNeeded);


            int bedCapacityLeft = int.MaxValue;
            foreach (var room in targetHotel.Rooms.All())
            {
                var currentBedCapacityLeft = room.BedCapacity - guestCapacityNeeded;

                if (currentBedCapacityLeft >= 0 && currentBedCapacityLeft < bedCapacityLeft)
                {
                    bedCapacityLeft = currentBedCapacityLeft;
                }
            }

            IRoom targetRoom = targetHotel.Rooms.All().First(r => r.BedCapacity - guestCapacityNeeded == bedCapacityLeft);

            if (targetRoom == null)
            {
                return OutputMessages.RoomNotAppropriate;
            }

            IBooking booking = new Booking(targetRoom, duration, adults, children, (targetHotel.Bookings.All().Count + 1));
            targetHotel.Bookings.AddNew(booking);

            return String.Format(OutputMessages.BookingSuccessful, booking.BookingNumber, targetHotel.FullName);
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = this.hotelRepository.Select(hotelName);

            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");

            if (hotel.Bookings.All().Any())
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine(booking.BookingSummary());
                }
            }
            else
            {
                sb.AppendLine("none");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
