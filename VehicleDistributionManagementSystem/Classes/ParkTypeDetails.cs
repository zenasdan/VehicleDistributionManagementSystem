using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDistributionManagementSystem.Classes
{
    public class ParkTypeDetails
    {
        public string ParkTypeName { get; set; }
        public double HourlyRate { get; set; }

        public ParkTypeDetails(string typeName, double rate)
        {
            ParkTypeName = typeName;
            HourlyRate = rate;
        }
    }
}
