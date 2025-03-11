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
            passengers = CsvFileHelper.ReadFromFile<Passenger>("C:\\Users\\hp\\source\\repos\\AirportBooking\\AirportBooking\\passengers.csv");
            flights = CsvFileHelper.ReadFromFile<Flight>("C:\\Users\\hp\\source\\repos\\AirportBooking\\AirportBooking\\flights.csv");
            Bookings= CsvFileHelper.ReadFromFile<Booking>("C:\\Users\\hp\\source\\repos\\AirportBooking\\AirportBooking\\bookings.csv");
        }

    }

}
