using AirportBooking.Data;
using AirportBooking.models;
using AirportBooking.Records;


namespace AirportBooking.Services.PassengerServices
{
    class FlightSearchService
    {
        public List<Flight> SearchFlights(FlightSearchParameters flightSearchParameters)
        {
            var query = DataStore.Flights
                .Where(flight =>
                    (string.IsNullOrEmpty(flightSearchParameters.Airline) ? true : flight.Airline == flightSearchParameters.Airline) &&
                    (string.IsNullOrEmpty(flightSearchParameters.DepartureCountry) ? true : flight.DepartureCountry == flightSearchParameters.DepartureCountry) &&
                    (string.IsNullOrEmpty(flightSearchParameters.DestinationCountry) ? true : flight.DestinationCountry == flightSearchParameters.DestinationCountry) &&
                    (string.IsNullOrEmpty(flightSearchParameters.DepartureAirport) ? true : flight.DepartureAirport == flightSearchParameters.DepartureAirport) &&
                    (string.IsNullOrEmpty(flightSearchParameters.ArrivalAirport) ? true : flight.ArrivalAirport == flightSearchParameters.ArrivalAirport) &&
                    (!flightSearchParameters.DepartureDate.HasValue ? true : flight.DepartureDate.Date == flightSearchParameters.DepartureDate.Value.Date) &&
                    (!flightSearchParameters.ArrivalDate.HasValue ? true : flight.ArrivalDate.Date == flightSearchParameters.ArrivalDate.Value.Date) &&
                    (!flightSearchParameters.AvailableSeats.HasValue ? true : flight.AvailableSeats >= flightSearchParameters.AvailableSeats.Value) &&
                    (!flightSearchParameters.Price.HasValue ? true : flight.ClassPrices.Values.Any(price => price == flightSearchParameters.Price.Value))
                );

            return query.ToList();
        }

    }

}
