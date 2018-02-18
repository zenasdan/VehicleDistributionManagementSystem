using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleDistributionManagementSystem.Classes;

namespace VehicleDistributionManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkStruct parkStruct = new ParkStruct();
            Car car = new Car("Zenas Dan", "L23DF323", ParkType.FrequentFlyer);
            parkStruct.AddCar("L1", 1, car);
            parkStruct.RemoveCar("L1", 1);
            Car car2 = new Car("Jake Dan", "LDIOVWED", ParkType.General);
            parkStruct.AddCar("L1", 1, car2);
            Car car3 = new Car("Dav Dan", "L23D2DF2", ParkType.FrequentFlyer);
            parkStruct.AddCar("L1", 2, car3);
            Console.WriteLine("Parking Cost: {0}", parkStruct.ParkingCost("L1", 1));
            Console.WriteLine("Parking Cost2: {0}", parkStruct.ParkingCost("L1", 2));

            Console.WriteLine("Owner: {0}, {1}", parkStruct.GetOwner("L1", 1).Item1, parkStruct.GetOwner("L1", 1).Item2);
            Console.WriteLine("Owner2: {0}, {1}", parkStruct.GetOwner("L1", 3).Item1, parkStruct.GetOwner("L1", 3).Item2);

            Console.WriteLine("Parking Space: {0}, {1}", parkStruct.GetParkingSpace("Jake Dan", "LDIOVWED").Item1, parkStruct.GetParkingSpace("Jake Dan", "LDIOVWED").Item2);
            Console.WriteLine("Parking Space2: {0}, {1}", parkStruct.GetParkingSpace("Dav Dan", "L23D2DF2").Item1, parkStruct.GetParkingSpace("Dav Dan", "L23D2DF2").Item2);

            Console.ReadLine();
        }
    }
}
