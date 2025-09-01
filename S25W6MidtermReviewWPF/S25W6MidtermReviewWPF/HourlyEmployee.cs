using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S25W6MidtermReview
{
    public class HourlyEmployee : Employee
    {
        public int hours { get; set; }
        public double wage { get; set; }

        public HourlyEmployee(string name, int hours, double wage) : base(name)
        {
            this.hours = hours;
            this.wage = wage;
        }

        public override double GrossEarnings()
        {
            if (Hours <= 40)
                return hours * wage;
            else
                return (40 * wage) + ((hours - 40) * wage * 1.5);
        }
    }
}
