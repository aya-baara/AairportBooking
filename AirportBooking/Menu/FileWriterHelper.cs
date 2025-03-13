using AirportBooking.Data;

namespace AirportBooking.Menu
{
    class FileWriterHelper
    {
        public static void writeBookingsToFile()
        {
            CsvFileHelper.WriteToFile(DataStore.Bookings, "C:\\Users\\hp\\source\\repos\\AirportBooking\\AirportBooking\\bookings.csv");
        }
    }
}
