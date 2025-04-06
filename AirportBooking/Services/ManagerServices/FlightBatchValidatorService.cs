using AirportBooking.Data;
using AirportBooking.models;


namespace AirportBooking.Services.ManagerServices
{
    class FlightBatchValidatorService
    {
        public static Dictionary<string, List<string>> GetValidationFlightRules()
        {
            return ValidationHelperService.GetValidationRules(typeof(Flight));
        }

        public static List<string> ReadAndValidate(string filePath)
        {
            List<string> allErrors = new List<string>(); 
            List<Flight> flights = CsvFileHelper.ReadFromFile<Flight>(filePath);

            foreach (var f in flights)
            {
                List<string> errors = ValidationHelperService.ValidateModel(f);
                allErrors.AddRange(errors);
            }

            return allErrors; 
        }

    }
}
