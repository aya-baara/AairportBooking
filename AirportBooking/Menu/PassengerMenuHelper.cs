using AirportBooking.Comparer;
using AirportBooking.Data;
using AirportBooking.Display;
using AirportBooking.Enums;
using AirportBooking.Exceptions;
using AirportBooking.models;
using AirportBooking.Records;
using AirportBooking.Services.PassengerServices;



namespace AirportBooking.Menu
{
    class PassengerMenuHelper
    {
        public int PassengerId { get; init; }

         Passenger passenger;

        public PassengerMenuHelper(int passengerId)
        {
            passenger = DataStore.Passengers.SingleOrDefault(pass => pass.Id == passengerId);
        }

        BookingService bookingService = new BookingService();
        FlightSearchService flightSearchService = new FlightSearchService();
        public bool BookFlight()
        {
            Console.Write("Enter the Flight ID (integer): ");
            bool isValidFlightId = int.TryParse(Console.ReadLine(), out int flightId);

            if (!isValidFlightId)
            {
                Console.WriteLine("Invalid Flight ID. Please enter a valid integer.");
                return false;
            }

            Flight flight = DataStore.Flights.SingleOrDefault(f => f.FlightId == flightId);
            if (flight == null)
            {
                Console.WriteLine("Invalid Flight ID. Flight not exist");
                return false;
            }


            Console.WriteLine("Select the class type for the flight:");
            Console.WriteLine("1. Business");
            Console.WriteLine("2. First Class");
            Console.WriteLine("3. Economy");
            Console.Write("Please enter your choice (1, 2, or 3): ");
            string classChoice = Console.ReadLine();

            SeatClass classType;
            switch (classChoice)
            {
                case "1":
                    classType = SeatClass.Business;
                    break;
                case "2":
                    classType = SeatClass.FirstClass;
                    break;
                case "3":
                    classType = SeatClass.Economy;
                    break;
                default:
                    Console.WriteLine("Invalid class choice. Returning to menu.");
                    return false;
            }



            try
            {

                bookingService.BookFlight(passenger, flight, classType);
                Console.WriteLine("Booking successfully completed!");
                return true;
            }
            catch (InvalidBookingException ex)
            {

                Console.WriteLine($"Booking failed: {ex.Message}");
                return false;
            }
        }

        public void ViewAvailbleFlights()
        {

            foreach (var flight in bookingService.ViewAvailbleFlights())
            {
                Console.WriteLine(FlightDisplay.GetFlightDetails(flight));
            }
        }

        public void CancelBooking()
        {
            Console.Write("Enter the Flight ID to cancel (integer): ");
            bool isValidFlightId = int.TryParse(Console.ReadLine(), out int flightId);

            if (!isValidFlightId)
            {
                Console.WriteLine("Invalid Flight ID. Please enter a valid integer.");
                return;
            }
            Flight flight = DataStore.Flights.SingleOrDefault(f => f.FlightId == flightId);
            if (flight == null)
            {
                Console.WriteLine("Invalid Flight ID. Flight not exist");
                return;
            }

            Console.Write("Are you sure you want to cancel the booking for Flight ID {0}? (y/n): ", flightId);
            string confirmation = Console.ReadLine();

            if (confirmation.ToLower() == "y")
            {

                bookingService.CancelBooking(passenger, flight);
                Console.WriteLine("Booking cancelled successfully.");
            }
            else
            {
                Console.WriteLine("Cancellation aborted.");
            }
        }

        public void ViewBookings()
        {
            List<Booking> bookings = bookingService.ViewPersonalBooking(passenger);

            if (bookings.Count == 0)
            {
                Console.WriteLine("No Bookings For you");
                return;
            }
            foreach (var booking in bookings)
            {
                Console.WriteLine(BookingDisplay.GetBookingDetails(booking));
            }
            
        }

        public void ModifyBooking()
        {
            // Ask the user to enter a valid flight ID
            Console.Write("Enter the Flight ID to modify (integer): ");
            bool isValidFlightId = int.TryParse(Console.ReadLine(), out int flightId);

            if (!isValidFlightId)
            {
                Console.WriteLine("Invalid Flight ID. Please enter a valid integer.");
                return; // Exit if the input is not a valid integer
            }

            Flight flight = DataStore.Flights.SingleOrDefault(f => f.FlightId == flightId);
            if (flight == null)
            {
                Console.WriteLine("Invalid Flight ID. Flight not exist");
                return;
            }

            // Ask the user to choose which class they want to modify
            Console.WriteLine("Select the class you want to modify:");
            Console.WriteLine("1. Business");
            Console.WriteLine("2. First Class");
            Console.WriteLine("3. Economy");
            Console.Write("Please enter your choice (1, 2, or 3): ");
            string classChoice = Console.ReadLine();

            SeatClass classType;
            switch (classChoice)
            {
                case "1":
                    classType = SeatClass.Business;
                    break;
                case "2":
                    classType = SeatClass.FirstClass;
                    break;
                case "3":
                    classType = SeatClass.Economy;
                    break;
                default:
                    Console.WriteLine("Invalid class choice. Returning to menu.");
                    return; // Return if the user selects an invalid class
            }
            BookingComparer bComparer = new BookingComparer();
          
            Booking bookingToModify = DataStore.Bookings.SingleOrDefault(book => book.PassengerId == passenger.Id && book.FlightId == flight.FlightId);

            if (bookingToModify == null)
            {
                Console.WriteLine("No booking found for this flight.");
                return; 
            }

            
            Console.Write("Are you sure you want to modify the booking for Flight ID {0}? (y/n): ", flightId);
            string confirmation = Console.ReadLine();

            if (confirmation.ToLower() == "y")
            {
                Booking newBooking = new Booking();
                newBooking.FlightId = bookingToModify.FlightId;
                newBooking.PassengerId = bookingToModify.PassengerId;
                newBooking.ClassType = classType;


                bookingService.ModifyBooking(passenger, newBooking);
                Console.WriteLine("Booking modified successfully.");
            }
            else
            {
                Console.WriteLine("Modification aborted.");
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

        public void writeBookingsToFile()
        {
            CsvFileHelper.WriteToFile(DataStore.Bookings, "C:\\Users\\hp\\source\\repos\\AirportBooking\\AirportBooking\\bookings.csv");
        }

    }


}
