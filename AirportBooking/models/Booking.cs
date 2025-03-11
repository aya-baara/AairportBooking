using AirportBooking.Enums;


namespace AirportBooking.models
{
    public class Booking
    {
       
        public int PassengerId { get; set; } 
        public int FlightId { get; set; }  
        public SeatClass ClassType { get; set; }  
        public decimal Price { get; set; }  
        public DateTime BookingDate { get; set; }

        public Booking(int passengerId, int flightId, SeatClass classType, decimal price, DateTime bookingDate)
        {
            
            PassengerId = passengerId;
            FlightId = flightId;
            ClassType = classType;
            Price = price;
            BookingDate = bookingDate;
        }
        public Booking() { }
    }
}
