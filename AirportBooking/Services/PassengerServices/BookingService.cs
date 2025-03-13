using AirportBooking.Comparer;
using AirportBooking.Data;
using AirportBooking.Enums;
using AirportBooking.Exceptions;
using AirportBooking.models;


namespace AirportBooking.Services.PassengerServices
{
    class BookingService
    {
        public void BookFlight(Passenger passenger,Flight flight, SeatClass classType) {

            if (flight.AvailableSeats <= 0) {
                throw new InvalidBookingException("No Availble seats !");
            }
            if (DateTime.Today >= flight.DepartureDate.Date)
            {
                throw new InvalidBookingException("Booking is not allowed for past or today's flights.");
            }

            if(DataStore.Bookings.SingleOrDefault(booking=> booking.PassengerId == passenger.Id &&booking.FlightId ==flight.FlightId)!= null)
            {
                throw new InvalidBookingException("You already booked the flight.");
            }

            DataStore.Bookings.Add(new Booking(
                    passenger.Id, flight.FlightId, classType, flight.ClassPrices.GetValueOrDefault(classType,0), DateTime.Now
                ));
            flight.AvailableSeats--;

        
        }

        public bool CancelBooking(Passenger passenger, Flight flight)
        {
            var booking= DataStore.Bookings.FirstOrDefault(booking => booking.PassengerId == passenger.Id && booking.FlightId==flight.FlightId);
            if (booking == null)
                return false; // Booking not found

            return DataStore.Bookings.Remove(booking);
                  

        }

        public List<Booking> ViewPersonalBookings(Passenger passenger)
        {
            return DataStore.Bookings.Where(booking => booking.PassengerId == passenger.Id).ToList();
        }

        public void ModifyBooking(Passenger passenger,Booking newBooking)
        {
            BookingComparer bComparer = new BookingComparer();
            Booking booking = DataStore.Bookings
                                .FirstOrDefault(book => bComparer.Equals(book, newBooking));
            if (booking == null)
            {
                throw new InvalidOperationException("Flight not found.");
            }

            if (Enum.IsDefined(typeof(SeatClass), newBooking.ClassType) && newBooking.ClassType != default)
            {
                Flight flight = DataStore.Flights.SingleOrDefault(flight => flight.FlightId == newBooking.FlightId);
                booking.ClassType = newBooking.ClassType;
                booking.Price = flight.ClassPrices.GetValueOrDefault(newBooking.ClassType);

            }
        }

        public List<Flight> ViewAvailbleFlights()
        {
            return DataStore.Flights.Where(flight => flight.AvailableSeats > 0 && flight.DepartureDate> DateTime.Today).ToList();
           
        }
    }   
}
