using CarServiceCare.Core.Contracts;
using CarServiceCare.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCare.Core.ViewModels
{
    public class AnyModelToCarViewModel<T> where T: BaseEntity
    {
        public IEnumerable<Car> Cars { get; set; }
        [Required(ErrorMessage = "Auto musí být vybráno")]
        public string CarId { get; set; }
        public T Model { get; set; }

    }
}
