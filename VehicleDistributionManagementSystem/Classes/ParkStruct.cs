using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDistributionManagementSystem.Classes
{
    public class ParkStruct
    {
        public Dictionary<Tuple<string, int>, ParkSpace> ParkingStruct { get; private set; }

        public ParkStruct()
        {
            ParkingStruct = new Dictionary<Tuple<string, int>, ParkSpace>();
        }

        //Adds a car to a given parking space on a given level. Based off the parking level chosen, you will be charged a certain price
        public void AddCar(string spaceLevel, int spaceNumber, Car car)
        {
            Tuple<string, int> spaceCoord = new Tuple<string, int>(spaceLevel, spaceNumber);
            if (ParkingStruct.ContainsKey(spaceCoord))
            {
                if(ParkingStruct[spaceCoord].Car == null)
                {
                    car.ParkStart = DateTime.Now;
                    ParkingStruct[spaceCoord].Car = car;
                }
                else
                {
                    throw new Exception("Sorry, space is already occupied.");
                }
            }
            else
            {
                ParkingStruct.Add(new Tuple<string, int>(spaceLevel, spaceNumber), new ParkSpace(car));
            }
        }

        //Remove the car from a given parking space on a given level
        public void RemoveCar(string spaceLevel, int spaceNumber)
        {
            Tuple<string, int> spaceCoord = new Tuple<string, int>(spaceLevel, spaceNumber);
            if (ParkingStruct.ContainsKey(spaceCoord))
            {
                if (ParkingStruct[spaceCoord].Car != null)
                {
                    //JUST ADDED 1 HOUR SO THAT WE ACTUALLY GET A VALUE FOR TOTAL COST WHEN TESTING
                    double totalCost = (DateTime.Now.Subtract(ParkingStruct[spaceCoord].Car.ParkStart).Hours + 1) * ParkingStruct[spaceCoord].Car.HourlyRate;
                    Console.WriteLine($"Goodbye. Your total cost is {totalCost}");
                    ParkingStruct[spaceCoord].Car = null;
                }
                else
                {
                    throw new Exception("There is no car to remove.");
                }
            }
        }

        //Given a parking space and a level, provide the total cost of the parking
        public double ParkingCost(string spaceLevel, int spaceNumber)
        {
            Tuple<string, int> spaceCoord = new Tuple<string, int>(spaceLevel, spaceNumber);
            if (ParkingStruct.ContainsKey(spaceCoord))
            {
                if (ParkingStruct[spaceCoord].Car != null)
                {
                    //JUST ADDED 1 HOUR SO THAT WE ACTUALLY GET A VALUE FOR TOTAL COST WHEN TESTING
                    double totalCost = (DateTime.Now.Subtract(ParkingStruct[spaceCoord].Car.ParkStart).Hours + 1) * ParkingStruct[spaceCoord].Car.HourlyRate;
                    Console.WriteLine($"Your current total is {totalCost}");
                    return totalCost;
                }
                else
                {
                    throw new Exception("This space is empty.");
                }
            }
            else
            {
                throw new Exception("This space is empty.");
            }
        }

        //Given a parking space and a level, get the license plate and owner of the car
        public Tuple<string, string> GetOwner(string spaceLevel, int spaceNumber)
        {
            Tuple<string, int> spaceCoord = new Tuple<string, int>(spaceLevel, spaceNumber);
            if (ParkingStruct.ContainsKey(spaceCoord))
            {
                if (ParkingStruct[spaceCoord].Car != null)
                {
                    return new Tuple<string, string>(ParkingStruct[spaceCoord].Car.OwnerFullName, ParkingStruct[spaceCoord].Car.LicensePlate);
                }
                else
                {
                    throw new Exception("This space is empty.");
                }
            }
            else
            {
                throw new Exception("This space is empty");
            }
        }

        //Given a name or license plate, return the level and space on that level where the car is parked.
        public Tuple<string, int> GetParkingSpace(string ownerFullName, string licensePlate)
        {
            Tuple<string, int> key = ParkingStruct.FirstOrDefault(x => x.Value.Car.OwnerFullName == ownerFullName && x.Value.Car.LicensePlate == licensePlate).Key;
            if (key == null)
            {
                throw new Exception("This owner is not in this parking structure.");
            }
            else
            {
                return key;
            }
        }
    }
}
