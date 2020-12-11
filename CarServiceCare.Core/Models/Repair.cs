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
