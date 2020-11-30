using CarServiceCare.Core.Models;
using System.Data.Entity;

namespace CarServiceCare.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection") { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarInsurance> CarInsurances { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Refueling> Refuelings { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<STK> STK { get; set; }
        public DbSet<TireChange> TireChanges { get; set; }

    }


}
