using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCare.Core.Models
{
    public class CarInsurance : BaseEntity
    {
        public Car Car { get; set; }
        [Display(Name = "Druh pojištění")]
        public string InsuranceType { get; set; }
        [Display(Name = "Pojišťovna")]
        public string InsuranceCompany { get; set; }
        [Display(Name = "Platné do")]
        public DateTime ValidTo { get; set; }
        [Display(Name = "Cena")]
        [Range(0, 999999)]
        public decimal Price { get; set; }

    }
}
