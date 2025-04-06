

namespace AirportBooking.Exceptions
{
    public class InvalidBookingException : Exception
    {
        public InvalidBookingException(string message = "Invalid booking operation.") : base(message)
        {
        }
    }
}
