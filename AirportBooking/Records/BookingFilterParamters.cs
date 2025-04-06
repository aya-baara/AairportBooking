using AirportBooking.Enums;


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
