using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCare.Core.Models
{
    public class Car : BaseEntity
    {
        public string CarBrand { get; set; }
        public string Model { get; set; }
        public string VehicleType { get; set; }
        public string FuelType { get; set; }
        public int CubicCapacity { get; set; }
        public int Power { get; set; }
        public string Category { get; set; }
        public DateTime FirstRegistration { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public int VIN { get; set; }
        public int Kilometer { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public int Owners { get; set; }

    }
}
