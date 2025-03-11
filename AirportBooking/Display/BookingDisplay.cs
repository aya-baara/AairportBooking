using AirportBooking.models;


namespace AirportBooking.Display
{
    class BookingDisplay
    {
        public static string GetBookingDetails(Booking booking)
        {
            return $"""
            Booking Details =>
            Passenger ID: {booking.PassengerId}
            Flight ID: {booking.FlightId}
            Class: {booking.ClassType}
            Price: ${booking.Price}
            Booking Date: {booking.BookingDate:yyyy-MM-dd HH:mm}
            """;
        }
    }
}
