

namespace AirportBooking.models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public Passenger(int id, string name, string email, int phoneNumber)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public Passenger() { }
    }
}
