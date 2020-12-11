using System.ComponentModel.DataAnnotations;

namespace CarServiceCare.Core.Models
{
    public class Service : BaseEntity
    {

        [Display(Name = "Auto")]
        public Car Car { get; set; }
        //Kategorie
        [Display(Name = "Druh servisního zásahu")]
        public string ServiceType { get; set; }
        //Servis
        [Display(Name = "Servis kde oprava proběhla")]
        public string CarService { get; set; }
        //Rozsah
        [Display(Name = "Výrobce")]
        public string Description { get; set; }
        //Tachometr
        public string Kilometer { get; set; }
        //Cena
        [Range(0, 999999)]
        public decimal Price { get; set; }

    }
}
