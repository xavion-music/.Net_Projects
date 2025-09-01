using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExample
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Salary { get; set; }

        public Employee(int id, string name, string salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"Id: {Id}\n Name: {Name}\n Salary: {Salary:C}\n\n";
        }   

    }
}
