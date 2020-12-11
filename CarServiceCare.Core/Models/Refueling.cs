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
    public class Refueling : BaseEntity
    {

        [Display(Name = "Auto")]
        public Car Car { get; set; }
        //Stanice
        [Display(Name = "Čerpací Stanice")]
        public string FuelStation { get; set; }
        //Palivo
        [Display(Name = "Druh paliva")]
        public FuelTypesEnum FuelType { get; set; }
        //Trasa
        [Display(Name = "Trasa")]
        public string Route { get; set; }
        //Styl jízdy
        [Display(Name = "Styl jízdy")]
        public string DrivingStyle { get; set; }
        //Ujeto
        [Display(Name = "Vzdálenost")]
        [Range(0, 999999)]
        public int Distance { get; set; }
        //Spotřeba
        [Display(Name = "Spotřeba")]
        [Range(0, 999999)]
        public int FuelConsumption { get; set; }
        //Litrů
        [Display(Name = "Spotřeba v litrech:")]
        [Range(0, 999999)]
        public int? Liters { get; set; }
        //Cena za litr
        [Display(Name = "Cena za litr")]
        [Range(0, 999999)]
        public decimal? PriceForLiter { get; set; }
        //Cena
        [Display(Name = "Celková cena")]
        [Range(0, 999999)]
        public decimal Price { get; set; }
    }
}
