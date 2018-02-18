using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDistributionManagementSystem.Classes
{
    public class Car
    {
        public string OwnerFullName { get; set; }
        public string LicensePlate { get; set; }
        public double TotalAmtDue { get; set; }
        public string UserType { get; set; }
        public double HourlyRate { get; set; }
        public DateTime ParkStart { get; set; }
        public Dictionary<ParkType, ParkTypeDetails> ParkingTypeDictionary { get; set; }

        public Car(string ownerFullName, string licensePlate, ParkType type)
        {
            ParkingTypeDictionary = new Dictionary<ParkType, ParkTypeDetails>()
            {
                { ParkType.FrequentFlyer, new ParkTypeDetails("Frequent Flyer", 10) },
                { ParkType.General, new ParkTypeDetails("General", 5) },
                { ParkType.Valet, new ParkTypeDetails("Valet", 3) }
            };
            OwnerFullName = ownerFullName;
            LicensePlate = licensePlate;
            ParkStart = DateTime.Now;
            TotalAmtDue = 0;
            UserType = ParkingTypeDictionary[type].ParkTypeName;
            HourlyRate = ParkingTypeDictionary[type].HourlyRate;
        }
    }
}
