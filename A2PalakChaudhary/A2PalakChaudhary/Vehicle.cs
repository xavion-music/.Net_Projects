using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2PalakChaudhary
{
    public abstract class Vehicle
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double RentalPrice { get; set; }
        public Category Category { get; set; }
        public VehicleType Type { get; set; }
        public bool IsReserved { get; set; }

        public virtual void Display()
        { 
            Console.WriteLine($"{ID,-3} {Name,-42} {RentalPrice,8:C}  {Category,-8} {Type,-7} {(IsReserved ? "Yes" : "No")}");
        }
    }
}
