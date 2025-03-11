
namespace AirportBooking.Menu
{
    using AirportBooking.Data;
    using System;


    public class Menu
    {
        

        public void DisplayMenu()
        {
            DataStore.ReadData();

            Console.WriteLine("Welcome to the Airport Ticket Booking System");
            Console.WriteLine("Are you a Passenger or a Manager?");
            Console.WriteLine("1. Passenger");
            Console.WriteLine("2. Manager");
            Console.Write("Please enter your choice (1 or 2): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PassengerMenu();
                    break;
                case "2":
                    ManagerMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select 1 for Passenger or 2 for Manager.");
                    break;
            }
        }

        private void PassengerMenu()
        {
            Console.Write("Enter your Passenger ID: ");
            int passengerId = int.Parse(Console.ReadLine());

            if (DataStore.passengers.SingleOrDefault(pass=>pass.Id==passengerId)==null)
            {
                Console.WriteLine("Passenger ID does not exist. Exiting...");
                return; // Exit if ID doesn't exist
            }
            PassengerMenuHelper passengerMenuHelper = new PassengerMenuHelper(passengerId);

            while (true)
            {
                Console.WriteLine($"Welcome What would you like to do?");
                Console.WriteLine("1. Book a Flight");
                Console.WriteLine("2. Modify a Booking");
                Console.WriteLine("3. Cancel a Booking");
                Console.WriteLine("4. View My Bookings");
                Console.WriteLine("5. View availble flights");
                Console.WriteLine("6. Search specific flight");
                Console.WriteLine("0. exit");
                Console.Write("Please enter your choice: ");
                string choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        passengerMenuHelper.BookFlight();
                        break;
                    case "2":
                        passengerMenuHelper.ModifyBooking();
                        break;
                    case "3":
                        passengerMenuHelper.CancelBooking();
                        break;
                    case "4":
                        passengerMenuHelper.ViewBookings();
                        break;
                    case "5":
                        passengerMenuHelper.ViewAvailbleFlights();
                        break;
                    case "6":
                        passengerMenuHelper.SearchFlights();
                        break;
                    case "0":
                        passengerMenuHelper.writeBookingsToFile();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Returning to main menu.");
                        break;
                }

            }
            
        }

        private void ManagerMenu()
        {
            ManagerMenuHelper managerMenuHelper = new ManagerMenuHelper();
            while (true)
            {
                Console.WriteLine("Welcome Manager! What would you like to do?");
                Console.WriteLine("1. Filter Bookings");
                Console.WriteLine("2. Batch Flight Upload");
                Console.WriteLine("3. Get Flight validation");
                Console.Write("Please enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        managerMenuHelper.FilterBookings();
                        break;
                    case "2":
                        managerMenuHelper.BatchFlightUpload();
                        break;
                    case "3":
                        managerMenuHelper.GetValidation();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Returning to main menu.");
                        break;
                }
            }
        }


    }

}
