using AirportBooking.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportBooking.Display
{
    class PassengerDisplay
    {
        public static string GetPassengerDetails(Passenger passenger)
        {
            return $"""
        Passenger Details => 
        ID: {passenger.Id}, 
        Name: {passenger.Name}, 
        Email: {passenger.Email}, 
        Phone: {passenger.PhoneNumber}
        """;
        }
    }
}
