using AirportBooking.Attributes;
using AirportBooking.Enums;
using System.ComponentModel.DataAnnotations;


namespace AirportBooking.models
{
    public class Flight
    {
        private static int _nextId = 1;
        [Required(ErrorMessage = "Departure Flight ID is required.")]
        public int FlightId { get; set; }

        [Required(ErrorMessage = "Airline is required.")]
        public string Airline { get; set; }

        [Required(ErrorMessage = "Departure country is required.")]
        public string DepartureCountry { get; set; }

        [Required(ErrorMessage = "Destination country is required.")]
        public string DestinationCountry { get; set; }

        [Required(ErrorMessage = "Departure airport is required.")]
        public string DepartureAirport { get; set; }

        [Required(ErrorMessage = "Arrival airport is required.")]
        public string ArrivalAirport { get; set; }

        [Required(ErrorMessage = "Departure date is required.")]
        [DataType(DataType.DateTime)]
        [FutureDateAttribute]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "Arrival date is required.")]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalDate { get; set; }

        [Range(1, 300, ErrorMessage = "Available seats must be between 1 and 300.")]
        public int AvailableSeats { get; set; }

        public Dictionary<SeatClass, decimal> ClassPrices { get; set; }

        public decimal BusinessPrice
        {
            get => ClassPrices.ContainsKey(SeatClass.Business) ? ClassPrices[SeatClass.Business] : 0;
            set => ClassPrices[SeatClass.Business] = value;
        }

        public decimal EconomyPrice
        {
            get => ClassPrices.ContainsKey(SeatClass.Economy) ? ClassPrices[SeatClass.Economy] : 0;
            set => ClassPrices[SeatClass.Economy] = value;
        }

        public decimal FirstClassPrice
        {
            get => ClassPrices.ContainsKey(SeatClass.FirstClass) ? ClassPrices[SeatClass.FirstClass] : 0;
            set => ClassPrices[SeatClass.FirstClass] = value;
        }

        public Flight()
        {
            ClassPrices = new Dictionary<SeatClass, decimal>
            {
                { SeatClass.Economy, 0 },
                { SeatClass.Business, 0 },
                { SeatClass.FirstClass, 0 }
            };
        }

        public Flight(string airline, string departureCountry, string destinationCountry,
                      string departureAirport, string arrivalAirport, DateTime departureDate, DateTime arrivalDate,
                      int availableSeats, Dictionary<SeatClass, decimal> classPrices)
        {
            FlightId = _nextId++;
            Airline = airline;
            DepartureCountry = departureCountry;
            DestinationCountry = destinationCountry;
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            AvailableSeats = availableSeats;
            ClassPrices = classPrices ?? new Dictionary<SeatClass, decimal>(); 
        }




    }
}
