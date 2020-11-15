using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCare.Core.Models
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        [Display(Name = "Vytvořeno")]
        public DateTimeOffset CreatedAt { get; set; }
        [Display(Name = "Poznámka")]
        public string Note { get; set; }
        [Display(Name = "Fotodokumentace")]
        public string Photo { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }
    }
}
