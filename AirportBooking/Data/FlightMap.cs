using AirportBooking.models;
using CsvHelper.Configuration;


namespace AirportBooking.Data
{
    public class FlightMap : ClassMap<Flight>
    {
        public FlightMap()
        {
            Map(f => f.FlightId);
            Map(f => f.Airline);
            Map(f => f.DepartureCountry);
            Map(f => f.DestinationCountry);
            Map(f => f.DepartureAirport);
            Map(f => f.ArrivalAirport);
            Map(f => f.DepartureDate);
            Map(f => f.ArrivalDate);
            Map(f => f.AvailableSeats);
            Map(f => f.BusinessPrice).Name("BusinessPrice");
            Map(f => f.EconomyPrice).Name("EconomyPrice");
            Map(f => f.FirstClassPrice).Name("FirstClassPrice");
        }
    }

}
