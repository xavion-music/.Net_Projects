using System;
using System.Collections.Generic;

namespace A1PalakChaudhary
{
    public class VendingMachine
    {

        List<VendItem> itms;
        double bal;

        public VendingMachine()
        {
            itms = new List<VendItem>();
            itms.Add(new VendItem("Soda", 1.5, 5));
            itms.Add(new VendItem("Chips", 1, 5));
            itms.Add(new VendItem("Candy Bar", 0.75, 5));
            bal = 0;
        }

        public void Show()
        {
            Console.WriteLine("\nItems:");
            for (int i = 0; i < itms.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + itms[i].Name + " ($" + itms[i].Price + ") - Stock: " + itms[i].Stock);
            }
        }

        public void Money(double m)
        {
            if (m > 0)
            {
                bal += m;
            }
            else
            {
                Console.WriteLine("wrong amount");
            }
        }

        public double GetB() { return bal; }

        public void Pick(int i)
        {
            if (i < 1 || i > itms.Count)
            {
                Console.WriteLine("invalid");
                return;
            }

            var x = itms[i - 1];

            if (x.Stock <= 0)
            {
                Console.WriteLine(x.Name + " out of stock");
                return;
            }

            if (bal < x.Price)
            {
                Console.WriteLine("insufficient funds" + " need " + (x.Price - bal).ToString("F2") + " more");
                return;
            }

            Console.WriteLine("Here is your " + x.Name + "\n");
            x.Stock--;
            Console.WriteLine("\nchange: $" + (bal - x.Price).ToString("F2"));
            bal = 0;
        }
    }
}
