using AirportBooking.models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace AirportBooking.Data
{
    class CsvFileHelper
    {
        public static List<T> ReadFromFile<T>(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                // Apply FlightMap ONLY if T is Flight
                if (typeof(T) == typeof(Flight))
                {
                    csv.Context.RegisterClassMap<FlightMap>();
                }
                return csv.GetRecords<T>().ToList();
            }
        }


        public static void WriteToFile<T>(List<T> records, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                // Apply FlightMap only if T is Flight
                if (typeof(T) == typeof(Flight))
                {
                    csv.Context.RegisterClassMap<FlightMap>();
                }
                csv.WriteRecords(records);
            }
        }

    }

}
