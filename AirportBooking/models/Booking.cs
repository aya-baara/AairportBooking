using AirportBooking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportBooking.models
{
    public class Booking
    {
       
        public int PassengerId { get; set; } 
        public int FlightId { get; set; }  
        public ClassType ClassType { get; set; }  
        public decimal Price { get; set; }  
        public DateTime BookingDate { get; set; }

        public Booking(int passengerId, int flightId, ClassType classType, decimal price, DateTime bookingDate)
        {
            
            PassengerId = passengerId;
            FlightId = flightId;
            ClassType = classType;
            Price = price;
            BookingDate = bookingDate;
        }
    }
}
