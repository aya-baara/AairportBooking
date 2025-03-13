using AirportBooking.Data;
using AirportBooking.Display;
using AirportBooking.models;
using AirportBooking.Records;
using AirportBooking.Services.PassengerServices;

namespace AirportBooking.Menu
{
    class PassengerFlightSearchMenuHelper
    {
        public int PassengerId { get; init; }
        Passenger passenger;
        FlightSearchService flightSearchService = new FlightSearchService();

        public PassengerFlightSearchMenuHelper(int passengerId)
        {

            try
            {
                passenger = DataStore.Passengers.SingleOrDefault(pass => pass.Id == passengerId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

        }

        public void SearchFlights()
        {
            Console.WriteLine("Select the search criteria:");
            Console.WriteLine("1. Airline");
            Console.WriteLine("2. Departure Country");
            Console.WriteLine("3. Destination Country");
            Console.WriteLine("4. Departure Airport");
            Console.WriteLine("5. Arrival Airport");
            Console.WriteLine("6. Departure Date");
            Console.WriteLine("7. Arrival Date");
            Console.WriteLine("8. Available Seats");
            Console.WriteLine("9. Price");
            Console.WriteLine("0. Search with the selected parameters");

            string? airline = null, departureCountry = null, destinationCountry = null, departureAirport = null, arrivalAirport = null;
            DateTime? departureDate = null, arrivalDate = null;
            int? availableSeats = null, price = null;

            while (true)
            {
                Console.Write("Enter your choice (0 to search): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Airline: ");
                        airline = Console.ReadLine();
                        break;

                    case "2":
                        Console.Write("Enter Departure Country: ");
                        departureCountry = Console.ReadLine();
                        break;

                    case "3":
                        Console.Write("Enter Destination Country: ");
                        destinationCountry = Console.ReadLine();
                        break;

                    case "4":
                        Console.Write("Enter Departure Airport: ");
                        departureAirport = Console.ReadLine();
                        break;

                    case "5":
                        Console.Write("Enter Arrival Airport: ");
                        arrivalAirport = Console.ReadLine();
                        break;

                    case "6":
                        Console.Write("Enter Departure Date (yyyy-MM-dd): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime depDate))
                        {
                            departureDate = depDate;
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format.");
                        }
                        break;

                    case "7":
                        Console.Write("Enter Arrival Date (yyyy-MM-dd): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime arrDate))
                        {
                            arrivalDate = arrDate;
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format.");
                        }
                        break;

                    case "8":
                        Console.Write("Enter Minimum Available Seats: ");
                        if (int.TryParse(Console.ReadLine(), out int seats))
                        {
                            availableSeats = seats;
                        }
                        else
                        {
                            Console.WriteLine("Invalid number format.");
                        }
                        break;

                    case "9":
                        Console.Write("Enter Maximum Price: ");
                        if (int.TryParse(Console.ReadLine(), out int maxPrice))
                        {
                            price = maxPrice;
                        }
                        else
                        {
                            Console.WriteLine("Invalid price format.");
                        }
                        break;

                    case "0":

                        FlightSearchParameters searchParams = new(
                            airline, departureCountry, destinationCountry, departureAirport, arrivalAirport, departureDate, arrivalDate, availableSeats, price
                        );


                        List<Flight> results = flightSearchService.SearchFlights(searchParams);


                        if (results.Count > 0)
                        {
                            Console.WriteLine("\nSearch Results:");
                            foreach (var flight in results)
                            {
                                Console.WriteLine(FlightDisplay.GetFlightDetails(flight));
                            }
                        }
                        else
                        {
                            Console.WriteLine("No flights found matching your criteria.");
                        }

                        return;

                    default:
                        Console.WriteLine("Invalid choice, please enter a valid option.");
                        break;
                }
            }
        }
    }
}
