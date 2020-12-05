using System.ComponentModel.DataAnnotations;

namespace CarServiceCare.Core.Enums.Insurance
{
    public enum InsuranceCompanyEnum
    {
        [Display(Name = "Allianz pojišťovna")]
        Allianz,
        [Display(Name = "AXA pojišťovna")]
        AXA,
        [Display(Name = "Česká podnikatelská pojišťovna")]
        CeskaPodnikatelska,
        [Display(Name = "Česká pojišťovna")]
        CeskaPojistovna,
        [Display(Name = "ČSOB pojišťovna")]
        CSOB,
        [Display(Name = "DIRECT pojištovna")]
        DIRECT,
        [Display(Name = "Generali pojišťovna")]
        GENERALI,
        [Display(Name = "Hasičská vzájemná pojišťovna")]
        HasickskaVzajemna,
        [Display(Name = "Kooperativa pojišťovna")]
        Kooperativa,
        [Display(Name = "Slavia pojišťovna")]
        Slavia,
        [Display(Name = "Triglav pojišťovna")]
        Triglav,
        [Display(Name = "UNIQA pojišťovna")]
        UNIQA,
        [Display(Name = "Wüstenrot pojišťovna")]
        Wüstenrot,
        [Display(Name = "Jiná")]
        Other
    }
}
