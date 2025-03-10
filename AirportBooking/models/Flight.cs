using AirportBooking.Attributes;
using AirportBooking.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportBooking.models
{
    public class Flight
    {
        private static int _nextId = 1;
        [Required(ErrorMessage = "Departure Flight ID is required.")]
        public int FlightId { get; set; }

        [Required(ErrorMessage = "Airline is required.")]
        public string Airline { get; set; }

        [Required(ErrorMessage = "Departure country is required.")]
        public string DepartureCountry { get; set; }

        [Required(ErrorMessage = "Destination country is required.")]
        public string DestinationCountry { get; set; }

        [Required(ErrorMessage = "Departure airport is required.")]
        public string DepartureAirport { get; set; }

        [Required(ErrorMessage = "Arrival airport is required.")]
        public string ArrivalAirport { get; set; }

        [Required(ErrorMessage = "Departure date is required.")]
        [DataType(DataType.DateTime)]
        [FutureDateAttribute]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "Arrival date is required.")]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalDate { get; set; }

        [Range(1, 300, ErrorMessage = "Available seats must be between 1 and 300.")]
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
