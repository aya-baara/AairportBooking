using AirportBooking.Data;
using AirportBooking.models;
using AirportBooking.Records;


namespace AirportBooking.Services.PassengerServices
{
    class FlightSearchService
    {
        public List<Flight> SearchFlights(FlightSearchParameters flightSearchParameters)
        {
            IEnumerable<Flight> query = DataStore.flights;

            if (!string.IsNullOrEmpty(flightSearchParameters.Airline))
            {
                query = query.Where(flight => flight.Airline == flightSearchParameters.Airline);
            }
            if (!string.IsNullOrEmpty(flightSearchParameters.DepartureCountry))
            {
                query = query.Where(flight => flight.DepartureCountry == flightSearchParameters.DepartureCountry);
            }
            if (!string.IsNullOrEmpty(flightSearchParameters.DestinationCountry))
            {
                query = query.Where(flight => flight.DestinationCountry == flightSearchParameters.DestinationCountry);
            }
            if (!string.IsNullOrEmpty(flightSearchParameters.DepartureAirport))
            {
                query = query.Where(flight => flight.DepartureAirport == flightSearchParameters.DepartureAirport);
            }
            if (!string.IsNullOrEmpty(flightSearchParameters.ArrivalAirport))
            {
                query = query.Where(flight => flight.ArrivalAirport == flightSearchParameters.ArrivalAirport);
            }
            if (flightSearchParameters.DepartureDate.HasValue)
            {
                query = query.Where(flight => flight.DepartureDate.Date == flightSearchParameters.DepartureDate.Value.Date);
            }
            if (flightSearchParameters.ArrivalDate.HasValue)
            {
                query = query.Where(flight => flight.ArrivalDate.Date == flightSearchParameters.ArrivalDate.Value.Date);
            }
            if (flightSearchParameters.AvailableSeats.HasValue)
            {
                query = query.Where(flight => flight.AvailableSeats >= flightSearchParameters.AvailableSeats.Value);
            }
            if (flightSearchParameters.Price.HasValue)
            {
                query = query.Where(flight => flight.ClassPrices.ContainsValue(flightSearchParameters.Price.Value) );
            }

            return query.ToList();
        }
    }

}
