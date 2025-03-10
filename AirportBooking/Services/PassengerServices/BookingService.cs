using AirportBooking.Comparer;
using AirportBooking.Data;
using AirportBooking.Enums;
using AirportBooking.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportBooking.Services.PassengerServices
{
    class BookingService
    {
        public void BookFlight(Passenger passenger,Flight flight, ClassType classType) {
            DataStore.Bookings.Add(new Booking(
                    passenger.Id, flight.FlightId, classType, flight.ClassPrices.GetValueOrDefault(classType,0), DateTime.Now
                ));

        
        }

        public bool CancelBooking(Passenger passenger, Flight flight)
        {
            var booking= DataStore.Bookings.FirstOrDefault(booking => booking.PassengerId == passenger.Id);
            if (booking == null)
                return false; // Booking not found

            return DataStore.Bookings.Remove(booking);
                  

        }

        public List<Booking>ViewPersonalBooking(Passenger passenger)
        {
            return DataStore.Bookings.Where(booking => booking.PassengerId == passenger.Id).ToList();
        }

        public bool ModifyBooking(Passenger passenger,Booking newBooking)
        {
            BookingComparer bComparer = new BookingComparer();
            Booking booking = DataStore.Bookings
                                .FirstOrDefault(book => bComparer.Equals(book, newBooking));
            if (booking == null)
            {
                return false;
            }
            if (newBooking.BookingDate != default(DateTime))
            {
                booking.BookingDate = newBooking.BookingDate;
            }

            if (Enum.IsDefined(typeof(ClassType), newBooking.ClassType) && newBooking.ClassType != default)
            {
                Flight flight = DataStore.flights.SingleOrDefault(flight => flight.FlightId == newBooking.FlightId);
                booking.ClassType = newBooking.ClassType;
                booking.Price = flight.ClassPrices.GetValueOrDefault(newBooking.ClassType);

            }

            return true;
        }
    }   
}
