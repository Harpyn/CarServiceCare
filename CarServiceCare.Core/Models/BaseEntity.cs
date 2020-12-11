using System;
using System.ComponentModel.DataAnnotations;

namespace CarServiceCare.Core.Models
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }

        [Display(Name = "Vytvořeno")]
        public DateTimeOffset CreatedAt { get; set; }


        [Display(Name = "Poznámka")]
        public string Note { get; set; }


        [Display(Name = "Foto")]
        public string Photo { get; set; }


        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }
    }
}
