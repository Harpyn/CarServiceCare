using System.ComponentModel.DataAnnotations;

namespace CarServiceCare.Core.Enums.Car
{
    public enum VehicleTypesEnum
    {
        [Display(Name = "Kombi")]
        Combi,
        [Display(Name = "MPV")]
        MPV,
        [Display(Name = "SUV")]
        SUV,
        [Display(Name = "CUV")]
        CUV,
        [Display(Name = "VAN")]
        VAN,
        [Display(Name = "Hatchback")]
        hatchback,
        [Display(Name = "Liftback")]
        liftback,
        [Display(Name = "Sedan / limuzína")]
        sedan,
        [Display(Name = "Sportovní")]
        Sports,
        [Display(Name = "Kabriolet")]
        convertible,
        [Display(Name = "Kupé")]
        coupe,
        [Display(Name = "Roadster")]
        roadster,
        [Display(Name = "Off-Road")]
        offroad,
        [Display(Name = "Pickup")]
        pickup,
        [Display(Name = "Jiné")]
        other,

    }
}
