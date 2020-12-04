using System.ComponentModel.DataAnnotations;

namespace CarServiceCare.Core.Enums
{
    public enum ExpensesEnum
    {
        [Display(Name = "Čistící prostředky")]
        Detergents,
        [Display(Name = "Dálniční známka - desetidenní")]
        HighwayTicketFor10Days,
        [Display(Name = "Dálniční známka - měsíční")]
        HighwayTicketForMonth,
        [Display(Name = "Dálniční známka - roční")]
        HighwayTicketForYear,
        [Display(Name = "Ostatní")]
        Other,
        [Display(Name = "Parkovné")]
        Parking,
        [Display(Name = "Stěrače")]
        Wipers,
        [Display(Name = "Voda do ostřikovačů")]
        WasherWater,
        [Display(Name = "Vůně do auta")]
        CarSmell
    }
}
