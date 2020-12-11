using System.ComponentModel.DataAnnotations;
using CarServiceCare.Core.Enums.Repair;

namespace CarServiceCare.Core.Models
{
    public class Repair : BaseEntity
    {

        [Display(Name = "Auto")]
        public Car Car { get; set; }
        //Oprava
        [Display(Name = "Druh opravy")]
        public string RepairType { get; set; }
        //Odhadovaná cena
        [Display(Name = "Odhadovaná cena")]
        [Range(0, 999999)]
        public decimal EstimatedPrice { get; set; }
        //Priorita
        [Display(Name = "Priorita")]
        public PriorityEnum Priority { get; set; }

    }
}
