using AirportBooking.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportBooking.Comparer
{
    public class BookingComparer : IEqualityComparer<Booking>
    {
        public bool Equals(Booking x, Booking y)
        {
            if (x == null || y == null)
                return false;

            return (x.FlightId== y.FlightId) && (x.PassengerId == y.PassengerId);
        }

        int IEqualityComparer<Booking>.GetHashCode(Booking obj)
        {
            if (obj == null)
                return 0;

            int bookingIdHashCode = obj.FlightId.GetHashCode();
            int passengerIdHashCode = obj.PassengerId.GetHashCode();

            // Combine them using XOR (^) or addition
            return bookingIdHashCode ^ passengerIdHashCode;
        }
    }
}
