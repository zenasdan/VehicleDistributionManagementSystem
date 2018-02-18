using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDistributionManagementSystem.Classes
{
    public class ParkTypeDict
    {
        public Dictionary<ParkType, ParkTypeDetails> ParkDict { get; set; }

        public ParkTypeDict()
        {
            ParkDict = new Dictionary<ParkType, ParkTypeDetails>()
            {
                { ParkType.FrequentFlyer, new ParkTypeDetails("Frequent Flyer", 10) },
                { ParkType.General, new ParkTypeDetails("General", 5) },
                { ParkType.Valet, new ParkTypeDetails("Valet", 3) }
            };
        }
    }
}
