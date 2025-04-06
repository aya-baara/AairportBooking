using AirportBooking.models;


namespace AirportBooking.Data
{
    public static class DataStore
    {
        public static List<Passenger> Passengers = new List<Passenger>();

        public static List<Flight> Flights = new List<Flight>();

        public static List<Booking> Bookings = new List<Booking>();

        public static void ReadData()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Path.GetFullPath(Path.Combine(basePath, FilePaths.BaseRelativePath));

            Passengers = CsvFileHelper.ReadFromFile<Passenger>(Path.Combine(projectRoot, FilePaths.PassengersFile));
            Flights = CsvFileHelper.ReadFromFile<Flight>(Path.Combine(projectRoot, FilePaths.FlightsFile));
            Bookings = CsvFileHelper.ReadFromFile<Booking>(Path.Combine(projectRoot, FilePaths.BookingsFile));
        }

    }

}
