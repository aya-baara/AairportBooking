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
        ________________________________________________
        Flight ID: {flight.FlightId}
        Airline: {flight.Airline}
        From: {flight.DepartureCountry} ({flight.DepartureAirport})
        To: {flight.DestinationCountry} ({flight.ArrivalAirport})
        Departure: {flight.DepartureDate}
        Arrival: {flight.ArrivalDate}
        Available Seats: {flight.AvailableSeats}
        
        Ticket Prices:
        {GetFlightClassPricesDetails(flight)}
        ________________________________________________
        """;
        }

        public static string GetFlightClassPricesDetails(Flight flight)
        {
            StringBuilder s = new StringBuilder();
            foreach(var cp in flight.ClassPrices)
            {
                s.Append($" {cp.Key}  : {cp.Value} \n");
            }
            return s.ToString();

        }

    }
    
}
