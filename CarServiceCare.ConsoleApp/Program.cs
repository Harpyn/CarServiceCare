using CarServiceCare.Core.Enums;
using CarServiceCare.Core.Enums.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCare.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CarBrandsEnum carBrandsEnum = new CarBrandsEnum();
            //carBrandsEnum.GetAllEnumsWithNames<CarBrandsEnum>();

            //FuelTypesEnum fuelTypesEnum = new FuelTypesEnum();
            //fuelTypesEnum.GetAllEnumsWithNames<FuelTypesEnum>();

            VehicleTypesEnum vehicleTypesEnum = new VehicleTypesEnum();
            vehicleTypesEnum.GetAllEnumsWithNames<VehicleTypesEnum>();

            Console.ReadKey();
        }
    }
}
