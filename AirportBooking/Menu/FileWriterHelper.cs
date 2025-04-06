using AirportBooking.Data;

namespace AirportBooking.Menu
{
    class FileWriterHelper
    {
        public static void writeBookingsToFile()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Path.GetFullPath(Path.Combine(basePath, FilePaths.BaseRelativePath));

            CsvFileHelper.WriteToFile(DataStore.Bookings, Path.Combine(projectRoot, FilePaths.BookingsFile));
        }
    }
}
