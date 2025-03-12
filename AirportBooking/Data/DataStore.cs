using AirportBooking.models;


namespace AirportBooking.Data
{
    public static class DataStore
    {
        public static List<Passenger> passengers = new List<Passenger>();

        public static List<Flight> flights = new List<Flight>();

        public static List<Booking> Bookings = new List<Booking>();

        public static void ReadData()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\"));

            passengers = CsvFileHelper.ReadFromFile<Passenger>(Path.Combine(projectRoot, "passengers.csv"));
            flights = CsvFileHelper.ReadFromFile<Flight>(Path.Combine(projectRoot, "flights.csv"));
            Bookings = CsvFileHelper.ReadFromFile<Booking>(Path.Combine(projectRoot, "bookings.csv"));
        }

    }

}
