using System.ComponentModel.DataAnnotations;

namespace CarServiceCare.Core.Enums.Insurance
{
    public enum TypeOfInsuranceEnum
    {
        [Display(Name = "Povinné ručení")]
        CarInsurance,
        [Display(Name = "Havarijní pojištění")]
        AccidentInsurance,
        [Display(Name = "Doplňkové pojištění")]
        SupplementaryInsurance
    }
}
