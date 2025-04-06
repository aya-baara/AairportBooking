using AirportBooking.models;


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
