using System.Xml.Linq;

namespace S25W6MidtermReview
{
    public abstract class Employee
    {
        public Employee(string name)
        {
            Name = name;
        }

        public abstract double GrossEarnings();

    }
}
