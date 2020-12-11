using CarServiceCare.Core.Enums.Insurance;
using System;
using System.ComponentModel.DataAnnotations;


namespace CarServiceCare.Core.Models
{
    public class CarInsurance : BaseEntity
    {
        [Display(Name = "Auto")]
        public Car Car { get; set; }

        [Display(Name = "Druh pojištění")]
        public TypeOfInsuranceEnum InsuranceType { get; set; }


        [Display(Name = "Pojišťovna")]
        public InsuranceCompanyEnum InsuranceCompany { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Platné do")]
        public DateTime ValidTo { get; set; }


        [Display(Name = "Cena")]
        [Range(0, 999999)]
        public decimal Price { get; set; }
    }
}
