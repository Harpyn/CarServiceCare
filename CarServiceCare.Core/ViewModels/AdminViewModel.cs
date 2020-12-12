using CarServiceCare.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCare.Core.ViewModels
{
    public class AdminViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<CarInsurance> CarInsurances { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
        public IEnumerable<Refueling> Refuelings { get; set; }
        public IEnumerable<Repair> Repairs { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<STK> STK { get; set; }
        public IEnumerable<TireChange> TireChanges { get; set; }

    }
}
