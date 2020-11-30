using CarServiceCare.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCare.Core.Models
{
    public class Car : BaseEntity
    {
        [Display(Name = "Výrobce")]
        public CarBrandsEnum CarBrand { get; set; }
        [Display(Name = "Druh")]
        public VehicleTypesEnum VehicleType { get; set; }
        [Display(Name = "Palivo")]
        public FuelTypesEnum FuelType { get; set; }
        [Display(Name = "Obsah")]
        [Range(0, 10)]
        public int CubicCapacity { get; set; }
        [Display(Name = "Výkon kW")]
        [Range(0, 2000)]
        public int Power { get; set; }
        [Display(Name = "VIN")]
        public int VIN { get; set; }
        [Display(Name = "Nájezd")]
        [Range(0, 999999)]
        public int Kilometer { get; set; }
        [Display(Name = "Počet majitelů")]
        [Range(0, 100)]
        public int Owners { get; set; }
        [Display(Name = "Cena")]
        [Range(0, 90000000)]
        public decimal Price { get; set; }
        [Display(Name = "Datum první registrace")]
        public DateTime FirstRegistration { get; set; }
        [Display(Name = "Datum zakoupení")]
        public DateTime DateOfPurchase { get; set; }
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Display(Name = "Barva")]
        public string Color { get; set; }
        [Display(Name = "SPZ")]
        public string LicensePlate { get; set; }
        [Display(Name = "Kategorie")]
        public string Category { get; set; }
        

        //reference to objects 1:N
        public ICollection<STK> STK { get; set; }
        public ICollection<CarInsurance> CarInsurances { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<Refueling> Refuelings { get; set; }
        public ICollection<Repair> Repairs { get; set; }
        public ICollection<Service> Services { get; set; }     
        public ICollection<TireChange> TireChanges { get; set; }

    }
}
