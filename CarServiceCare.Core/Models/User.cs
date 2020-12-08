using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCare.Core.Models
{
    public class User : BaseEntity
    {
        public string UserId { get; set; }
        [Display(Name = "Jméno")]
        public string FirstName { get; set; }
        [Display(Name = "Příjmení")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Zadání emailové adresy je povinné")]
        [EmailAddress(ErrorMessage = "Nesprávný formát")]
        public string Email { get; set; }
        [Display(Name = "Ulice")]
        public string Street { get; set; }
        [Display(Name = "Město")]
        public string City { get; set; }
        [Display(Name = "Stát")]
        public string State { get; set; }
        [Display(Name = "PSČ")]
        public string ZipCode { get; set; }
    }
}
