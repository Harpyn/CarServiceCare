using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCare.Core.Models
{
    public class STK : BaseEntity
    {
        public Car Car { get; set; }
        public DateTime ValidTo { get; set; }
        public string Station { get; set; }
        public string Description { get; set; }
        public int Kilometer { get; set; }
        public decimal? Price { get; set; }
        public string Note { get; set; }
        public bool Passed { get; set; }
    }
}
