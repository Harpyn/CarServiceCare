using System.ComponentModel.DataAnnotations;
using CarServiceCare.Core.Enums.Expense;

namespace CarServiceCare.Core.Models
{
    public class Expense : BaseEntity
    {

        [Display(Name = "Auto")]
        public Car Car { get; set; }
        //Druh
        [Display(Name = "Druh výdaje")]
        public ExpensesEnum Type { get; set; }
        //Cena
        [Display(Name = "Cena")]
        [Range(0, 999999)]
        public decimal Price { get; set; }

    }
}
