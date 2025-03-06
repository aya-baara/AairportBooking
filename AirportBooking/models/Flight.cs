using AirportBooking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportBooking.models
{
    public class Flight
    {
        private static int _nextId = 1;
        public int FlightId { get; set; } 
        public string Airline { get; set; }  
        public string DepartureCountry { get; set; }
        public string DestinationCountry { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int AvailableSeats { get; set; }
        public Dictionary<ClassType, decimal> ClassPrices { get; set; }

        public Flight()
        {
            ClassPrices = new Dictionary<ClassType, decimal>();
        }

        public Flight(string airline, string departureCountry, string destinationCountry,
                      string departureAirport, string arrivalAirport, DateTime departureDate, DateTime arrivalDate,
                      int availableSeats, Dictionary<ClassType, decimal> classPrices)
        {
            FlightId = _nextId;
            Airline = airline;
            DepartureCountry = departureCountry;
            DestinationCountry = destinationCountry;
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            AvailableSeats = availableSeats;
            ClassPrices = classPrices ?? new Dictionary<ClassType, decimal>(); 
        }




    }
}
