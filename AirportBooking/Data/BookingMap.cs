using AirportBooking.models;
using CsvHelper.Configuration;


namespace AirportBooking.Data
{
    public sealed class BookingMap : ClassMap<Booking>
    {
        public BookingMap()
        {
            Map(m => m.PassengerId).Index(0);
            Map(m => m.FlightId).Index(1);
            Map(m => m.ClassType).Index(2);
            Map(m => m.Price).Index(3);
            Map(m => m.BookingDate).Index(4).TypeConverterOption.Format("yyyy-MM-ddTHH:mm:ss");
        }
    }
}
