

namespace AirportBooking.Exceptions
{
    public class InvalidBookingException : Exception
    {
        public InvalidBookingException() : base("Invalid booking operation.")
        {
        }

        public InvalidBookingException(string message) : base(message)
        {
        }

    }

}
