using CarServiceCare.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCare.Core.Models
{
    public class Car : BaseEntity
    {
        public CarBrandsEnum CarBrand { get; set; }       
        public VehicleTypesEnum VehicleType { get; set; }
        public FuelTypesEnum FuelType { get; set; }       
        public int CubicCapacity { get; set; }
        public int Power { get; set; }
        public int VIN { get; set; }
        public int Kilometer { get; set; }
        public int Owners { get; set; }
        public decimal Price { get; set; }
        public DateTime FirstRegistration { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public string Category { get; set; }
        

        //reference to objects 1:N
        public ICollection<STK> STK { get; set; }

    }
}
