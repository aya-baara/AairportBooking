using AirportBooking.Data;
using AirportBooking.models;
using AirportBooking.Records;


namespace AirportBooking.Services.ManagerServices
{
    class BookingSearchService
    {
        public List<Booking> SearchBookings(BookingFilterParamters bookingFilter)
        {
            

            
            var query = from booking in DataStore.Bookings
                        join flight in DataStore.Flights on booking.FlightId equals flight.FlightId
                        select new { booking, flight };

            
            if (bookingFilter.PassengerId.HasValue)
            {
                query = query.Where(x => x.booking.PassengerId == bookingFilter.PassengerId.Value);
            }

            if (bookingFilter.FlightId.HasValue)
            {
                query = query.Where(x => x.booking.FlightId == bookingFilter.FlightId.Value);
            }

            if (bookingFilter.ClassType.HasValue)
            {
                query = query.Where(x => x.booking.ClassType == bookingFilter.ClassType.Value);
            }

            if (bookingFilter.Price.HasValue)
            {
                query = query.Where(x => x.booking.Price == bookingFilter.Price.Value);
            }

            if (bookingFilter.BookingDate.HasValue)
            {
                query = query.Where(x => x.booking.BookingDate.Date == bookingFilter.BookingDate.Value.Date);
            }

            if (!string.IsNullOrEmpty(bookingFilter.DepartureCountry))
            {
                query = query.Where(x => x.flight.DepartureCountry.Contains(bookingFilter.DepartureCountry));
            }

            if (!string.IsNullOrEmpty(bookingFilter.DestinationCountry))
            {
                query = query.Where(x => x.flight.DestinationCountry.Contains(bookingFilter.DestinationCountry));
            }

            if (bookingFilter.DepartureDate.HasValue)
            {
                query = query.Where(x => x.flight.DepartureDate.Date == bookingFilter.DepartureDate.Value.Date);
            }

            if (!string.IsNullOrEmpty(bookingFilter.DepartureAirport))
            {
                query = query.Where(x => x.flight.DepartureAirport.Contains(bookingFilter.DepartureAirport));
            }

            if (!string.IsNullOrEmpty(bookingFilter.ArrivalAirport))
            {
                query = query.Where(x => x.flight.ArrivalAirport.Contains(bookingFilter.ArrivalAirport));
            }

            var filteredBookings = query.Select(x => x.booking).ToList();

            return filteredBookings;
        }
    }


}
