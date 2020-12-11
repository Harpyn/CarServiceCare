using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCare.Core.Models
{
    public class TireChange : BaseEntity
    {

        [Display(Name = "Auto")]
        public Car Car { get; set; }
        //Počet
        [Display(Name = "Množství")]
        [Range(0, 99)]
        public int Quantity { get; set; }
        //Značka
        [Display(Name = "Značka")]
        public string TireManufacturer { get; set; }
        //Znovu vyváženo
        [Display(Name = "Vyváženo")]
        public string Balanced { get; set; }
        //Servis
        [Display(Name = "Servis kde výměna proběhla")]
        public string CarService { get; set; }
        //Tachometr
        [Display(Name = "Nájezd")]
        [Range(0, 999999)]
        public int Kilometer { get; set; }
        //Cena
        [Display(Name = "Cena")]
        [Range(0, 999999)]
        public decimal Price { get; set; }

    }
}
