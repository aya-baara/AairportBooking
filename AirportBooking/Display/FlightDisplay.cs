using AirportBooking.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportBooking.Display
{
    class FlightDisplay
    {
        public static string GetFlightDetails(Flight flight)
        {
            return $"""
        Flight Details =>
        Flight ID: {flight.FlightId}
        Airline: {flight.Airline}
        From: {flight.DepartureCountry} ({flight.DepartureAirport})
        To: {flight.DestinationCountry} ({flight.ArrivalAirport})
        Departure: {flight.DepartureDate}
        Arrival: {flight.ArrivalDate}
        Available Seats: {flight.AvailableSeats}
        
        Ticket Prices:
        - Economy: ${flight.EconomyPrice}
        - Business: ${flight.BusinessPrice}
        - First Class: ${flight.FirstClassPrice}
        """;
        }

    }
}
