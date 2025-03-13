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
    class PassengerBookingMenuHelper
    {
        public int PassengerId { get; init; }
        Passenger passenger;

        public PassengerBookingMenuHelper(int passengerId)
        {
            try 
            {
                passenger = DataStore.Passengers.SingleOrDefault(pass => pass.Id == passengerId);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);

            }
            
        }

        BookingService bookingService = new BookingService();
        
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
            List<Booking> bookings = bookingService.ViewPersonalBookings(passenger);

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

                try {
                    bookingService.ModifyBooking(passenger, newBooking);
                    Console.WriteLine("Booking modified successfully.");
                }
                catch (InvalidOperationException e) {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Modification aborted.");
            }
        }

    }


}
