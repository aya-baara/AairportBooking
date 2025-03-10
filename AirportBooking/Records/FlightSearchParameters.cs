using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportBooking.Records
{
    public record FlightSearchParameters
    (
        string? Airline = null ,
        string? DepartureCountry = null,
        string? DestinationCountry = null,
        string? DepartureAirport = null,
        string? ArrivalAirport = null,
        DateTime? DepartureDate = null,
        DateTime? ArrivalDate = null,
        int ? AvailableSeats = null,
        int ? Price = null
    );
}
