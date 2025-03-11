using AirportBooking.Enums;
using AirportBooking.models;
using AirportBooking.Records;
using AirportBooking.Services.ManagerServices;


namespace AirportBooking.Menu
{
    class ManagerMenuHelper
    {
        BookingSearchService bookingSearchService = new BookingSearchService();
        public void BatchFlightUpload()
        {
            var errors = BatchAndValidateService.ReadAndValidate("C:\\Users\\hp\\source\\repos\\AirportBooking\\AirportBooking\\flights.csv");
            if (errors.Count == 0)
            {
                Console.WriteLine("No errors Found");
            }
            foreach (var e in errors)
            {
                Console.WriteLine(e);
            }
           

        }

        public void FilterBookings()
        {
            Console.WriteLine("Select the booking filter criteria:");
            Console.WriteLine("1. Passenger ID");
            Console.WriteLine("2. Flight ID");
            Console.WriteLine("3. Class Type");
            Console.WriteLine("4. Price");
            Console.WriteLine("5. Booking Date");
            Console.WriteLine("6. Departure Country");
            Console.WriteLine("7. Destination Country");
            Console.WriteLine("8. Departure Date");
            Console.WriteLine("9. Departure Airport");
            Console.WriteLine("10. Arrival Airport");
            Console.WriteLine("0. Search with the selected parameters");

            int? passengerId = null, flightId = null;
            SeatClass? classType = null;
            decimal? price = null;
            DateTime? bookingDate = null, departureDate = null;
            string? departureCountry = null, destinationCountry = null, departureAirport = null, arrivalAirport = null;

            while (true)
            {
                Console.Write("Enter your choice (0 to search): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Passenger ID: ");
                        if (int.TryParse(Console.ReadLine(), out int pId))
                        {
                            passengerId = pId;
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID format.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter Flight ID: ");
                        if (int.TryParse(Console.ReadLine(), out int fId))
                        {
                            flightId = fId;
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID format.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Select Class Type:");
                        Console.WriteLine("1. Business");
                        Console.WriteLine("2. First Class");
                        Console.WriteLine("3. Economy");
                        Console.Write("Enter choice: ");
                        string classChoice = Console.ReadLine();

                        classType = classChoice switch
                        {
                            "1" => SeatClass.Business,
                            "2" => SeatClass.FirstClass,
                            "3" => SeatClass.Economy,
                            _ => null
                        };

                        if (classType == null)
                        {
                            Console.WriteLine("Invalid choice.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter Maximum Price: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal maxPrice))
                        {
                            price = maxPrice;
                        }
                        else
                        {
                            Console.WriteLine("Invalid price format.");
                        }
                        break;

                    case "5":
                        Console.Write("Enter Booking Date (yyyy-MM-dd): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime bDate))
                        {
                            bookingDate = bDate;
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format.");
                        }
                        break;

                    case "6":
                        Console.Write("Enter Departure Country: ");
                        departureCountry = Console.ReadLine();
                        break;

                    case "7":
                        Console.Write("Enter Destination Country: ");
                        destinationCountry = Console.ReadLine();
                        break;

                    case "8":
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

                    case "9":
                        Console.Write("Enter Departure Airport: ");
                        departureAirport = Console.ReadLine();
                        break;

                    case "10":
                        Console.Write("Enter Arrival Airport: ");
                        arrivalAirport = Console.ReadLine();
                        break;

                    case "0":
                        // Create filter parameter object
                        BookingFilterParamters filterParams = new(
                            passengerId, flightId, classType, price, bookingDate, departureCountry, destinationCountry, departureDate, departureAirport, arrivalAirport
                        );

                        // Call the actual search function
                        List<Booking> results = bookingSearchService.SearchBookings(filterParams);

                     
                        if (results.Count > 0)
                        {
                            Console.WriteLine("\nSearch Results:");
                            foreach (var booking in results)
                            {
                                Console.WriteLine($"Booking for Passenger {booking.PassengerId} on Flight {booking.FlightId} | {booking.ClassType} | {booking.Price}$ | Booking Date: {booking.BookingDate}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No bookings found matching your criteria.");
                        }

                        return; 

                    default:
                        Console.WriteLine("Invalid choice, please enter a valid option.");
                        break;
                }
            }
        }


        public void GetValidation()
        {
            var flightValidationRules = BatchAndValidateService.GetValidationFlightRules();

            Console.WriteLine("Flight Model Validation Rules:");
            foreach (var rule in flightValidationRules)
            {
                Console.WriteLine($"Property: {rule.Key}");
                Console.WriteLine($"Rules: {string.Join(", ", rule.Value)}");
                Console.WriteLine();
            }
        }
    }
}
