using System.ComponentModel.DataAnnotations;

namespace CarServiceCare.Core.Enums.Car
{
    public enum FuelTypesEnum
    {
        [Display(Name = "Benzín")]
        Petrol,
        [Display(Name = "Nafta")]
        Diesel,
        [Display(Name = "Elektrický")]
        Electric,
        [Display(Name = "Ethanol")]
        Ethanol,
        [Display(Name = "Hybrid")]
        Hybrid,
        [Display(Name = "LPG")]
        LPG,
        [Display(Name = "CNG")]
        CNG,
        [Display(Name = "Vodík")]
        Hydrogen,
        [Display(Name = "Jiné")]
        Other,
    }
}
