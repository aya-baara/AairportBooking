using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportBooking.models
{
    class Booking
    {
        public int BookingId { get; set; }  
        public int PassengerId { get; set; } 
        public int FlightId { get; set; }  
        public string ClassType { get; set; }  
        public decimal Price { get; set; }  
        public DateTime BookingDate { get; set; }
    }
}
