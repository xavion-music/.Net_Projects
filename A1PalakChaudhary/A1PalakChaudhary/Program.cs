using System;

namespace A1PalakChaudhary
{
    public class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vm = new VendingMachine();
            Console.WriteLine("Welcome\n");

            while (true)
            {
                Console.WriteLine("Balance: $" + vm.GetB().ToString("F2"));
                vm.Show();

                Console.Write("\ncommand: ");
                string z = Console.ReadLine().ToLower().Trim();

                if (z == "quit") break;

                else if (z.StartsWith("insert") || z.StartsWith("add"))
                {
                    var p = z.Split(' ');
                    if (p.Length == 2)
                    {
                        double d;
                        if (double.TryParse(p[1], out d)) vm.Money(d);
                        else Console.WriteLine("wrong command");
                    }
                    else Console.WriteLine("wrong format");
                }

                else if (z.StartsWith("select"))
                {
                    var p = z.Split(' ');
                    if (p.Length == 2)
                    {
                        int num;
                        if (int.TryParse(p[1], out num)) vm.Pick(num);
                        else Console.WriteLine("what number?");
                    }
                    else Console.WriteLine("Unidentified command or wrong item");
                }
                else Console.WriteLine("Invalid select");
            }
        }
    }
}
