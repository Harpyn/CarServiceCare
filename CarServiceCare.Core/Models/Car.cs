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
        [Display(Name = "Uživatel")]
        public User User { get; set; }
        [Display(Name = "Výrobce")]
        public CarBrandsEnum CarBrand { get; set; }
        [Display(Name = "Druh")]
        public VehicleTypesEnum VehicleType { get; set; }
        [Display(Name = "Palivo")]
        public FuelTypesEnum FuelType { get; set; }
        [Display(Name = "Obsah (ccm)")]
        [Range(0, 10)]
        public int CubicCapacity { get; set; }
        [Display(Name = "Výkon (kW)")]
        [Range(0, 2000)]
        public int Power { get; set; }
        [Display(Name = "VIN (17)")]
        [RegularExpression("^(?=.*[0-9])(?=.*[A-z])[0-9A-z-]{17}$", ErrorMessage = "VIN musí mít 17 znaků a nesmí obsahovat speciální znaky")]
        public string VIN { get; set; }
        [Display(Name = "Nájezd (Km)")]
        [Range(0, 999999)]
        public int Kilometer { get; set; }
        [Display(Name = "Počet majitelů")]
        [Range(0, 100)]
        public int Owners { get; set; }
        [Display(Name = "Cena (Kč)")]
        [Range(0, 90000000)]
        public decimal Price { get; set; }
        [Display(Name = "Datum první registrace")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FirstRegistration { get; set; }
        [Display(Name = "Datum zakoupení")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfPurchase { get; set; }
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Display(Name = "Barva")]
        public string Color { get; set; }
        [Display(Name = "SPZ")]
        public string LicensePlate { get; set; }      

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
