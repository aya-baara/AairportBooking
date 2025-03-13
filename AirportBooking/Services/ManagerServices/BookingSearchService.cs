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

            query = query.Where(x =>
                (bookingFilter.PassengerId.HasValue ? x.booking.PassengerId == bookingFilter.PassengerId.Value : true) &&
                (bookingFilter.FlightId.HasValue ? x.booking.FlightId == bookingFilter.FlightId.Value : true) &&
                (bookingFilter.ClassType.HasValue ? x.booking.ClassType == bookingFilter.ClassType.Value : true) &&
                (bookingFilter.Price.HasValue ? x.booking.Price == bookingFilter.Price.Value : true) &&
                (bookingFilter.BookingDate.HasValue ? x.booking.BookingDate.Date == bookingFilter.BookingDate.Value.Date : true) &&
                (string.IsNullOrEmpty(bookingFilter.DepartureCountry) ? true : x.flight.DepartureCountry.Contains(bookingFilter.DepartureCountry)) &&
                (string.IsNullOrEmpty(bookingFilter.DestinationCountry) ? true : x.flight.DestinationCountry.Contains(bookingFilter.DestinationCountry)) &&
                (bookingFilter.DepartureDate.HasValue ? x.flight.DepartureDate.Date == bookingFilter.DepartureDate.Value.Date : true) &&
                (string.IsNullOrEmpty(bookingFilter.DepartureAirport) ? true : x.flight.DepartureAirport.Contains(bookingFilter.DepartureAirport)) &&
                (string.IsNullOrEmpty(bookingFilter.ArrivalAirport) ? true : x.flight.ArrivalAirport.Contains(bookingFilter.ArrivalAirport))
            );

            var filteredBookings = query.Select(x => x.booking).ToList();

            return filteredBookings;
        }
    }


}
