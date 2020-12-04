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
    public class Expense : BaseEntity
    {
        //Auto na ktere se vykazuje vydaj
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
