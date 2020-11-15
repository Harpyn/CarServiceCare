using CarServiceCare.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCare.Core.Models
{
    public class STK : BaseEntity
    {
        public Car Car { get; set; }
        [Display(Name = "Platí do")]
        public DateTime ValidTo { get; set; }
        [Display(Name = "Stanice technické kontroly")]
        public string Station { get; set; }
        [Display(Name = "Popis závad atp.")]
        public string Description { get; set; }
        [Display(Name = "Nájezd")]
        [Range(0, 999999)]
        public int Kilometer { get; set; }
        [Display(Name = "Cena")]
        [Range(0, 99999999)]
        public decimal Price { get; set; }
        [Display(Name = "Výsledek")]
        public STKResultEnum Passed { get; set; }
    }
}
