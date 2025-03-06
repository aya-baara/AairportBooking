using AirportBooking.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportBooking.Data
{
    public static class DataStore
    {
        public static List<Passenger> passengers = new List<Passenger>()
        {
            new Passenger { Id = 1, Name = "John Doe", Email = "john@example.com", PhoneNumber = 05966565 },
            new Passenger { Id = 2, Name = "Jane Smith", Email = "jane@example.com", PhoneNumber = 6265656 }
        };

        public static List<Flight> flights = new List<Flight>()
        {
            new Flight { FlightId = 101, Airline = "Airways A", DepartureCountry = "USA", DestinationCountry = "UK", EconomyPrice = 500m, BusinessPrice = 1200m, FirstClassPrice = 2000m },
            new Flight { FlightId = 102, Airline = "Airways B", DepartureCountry = "Canada", DestinationCountry = "Germany", EconomyPrice = 450m, BusinessPrice = 1100m, FirstClassPrice = 1800m }
        };

        public  static List<Booking> Bookings = new List<Booking>
        {
            new Booking { BookingId = 1, PassengerId = 1, FlightId = 101, ClassType = "Economy", BookingDate = DateTime.Now }
        };

    }
}
