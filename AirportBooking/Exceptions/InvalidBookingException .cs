using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
