using AirportBooking.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AirportBooking.Records
{
    public record BookingFilterParamters(
        int? PassengerId = null ,
        int? FlightId = null ,
        SeatClass? ClassType = null ,
        decimal? Price = null ,
        DateTime? BookingDate = null ,
        string? DepartureCountry = null,
        string? DestinationCountry = null,
        DateTime? DepartureDate = null,
        string? DepartureAirport = null,
        string? ArrivalAirport = null

        );
    
}
