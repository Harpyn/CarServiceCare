using System.ComponentModel.DataAnnotations;

namespace CarServiceCare.Core.Enums
{
    public enum PriorityEnum
    {
        [Display(Name = "Nízká")]
        Low,
        [Display(Name = "Střední")]
        Medium,
        [Display(Name = "Vysoká")]
        High
    }
}
