using AirportBooking.models;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportBooking.Data
{
    public sealed class PassengerMap : ClassMap<Passenger>
    {
        public PassengerMap()
        {
            Map(m => m.Id).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.Email).Index(2);
            Map(m => m.PhoneNumber).Index(3);
        }
    }

}
