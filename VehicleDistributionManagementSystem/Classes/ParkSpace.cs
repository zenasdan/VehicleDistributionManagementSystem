using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDistributionManagementSystem.Classes
{
    public class ParkSpace
    {
        public Car Car { get; set; }

        public ParkSpace(Car car)
        {
            Car = car;
        }

    }
}
