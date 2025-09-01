using System;

namespace Week2
{
    // Custom class Circle with one property
    public class Circle
    {
        public double Radius { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 5;
            string str = "Hello, World!";
            Circle cir = new Circle();
            cir.Radius = 5.0;
            int[] arr = { 1, 2, 3, 4, 5 };

            Console.WriteLine("Before changes:\n");
            Console.WriteLine("num = " + num);
            Console.WriteLine("str = " + str);
            Console.WriteLine("cir.radius = " + cir.Radius);
            Console.WriteLine("arr[0] = " + arr[0]);

            // Call with all four parameters
            ChangeValue(ref num, str, cir, arr);

            Console.WriteLine("\nAfter changes:\n");
            Console.WriteLine("num = " + num);
            Console.WriteLine("str = " + str);
            Console.WriteLine("cir.radius = " + cir.Radius);
            Console.WriteLine("arr[0] = " + arr[0]);

            Console.WriteLine("\n\n");

            double r = 5;
            double circum, area;    

            CalculateCircumAndArea(r, out circum, out area); // Call with out parameters

            Console.WriteLine("Circumference = " + circum);
            Console.WriteLine("Area = " + area);

            /* Console.Write("\n\n Enter a number:");
             if (int.TryParse(Console.ReadLine(), out int n))
                 Console.WriteLine("You entered: " + n);

             else
             {

             }*/

            int a = 4, b = 6, c = 2;
            Console.WriteLine("a = " + a + ", b = " + b + ", c = " + c);
           // Console.WriteLine($"a = {a}, b = {b}, c = {c}");
            Console.WriteLine($"a = {a}, b = {b}, c = {c}"); // String interpolation

            Console.WriteLine("a = {0}, b = {1}, c = {2}", a, b, c); // String formatting

            // Console.WriteLine("n = " + n);

            //Parameter array example
            int[] arr2 = { 1, 2, 3, 4, 5 , 6, 7, 8, 9};

            PrintArray(myArr);
        }


        // parameter array example
        static void PrintArray(int[] arr)
        {
            Console.WriteLine("\n\nTotal number of items = "+arr.Length);

            foreach (int i in arr)
                Console.Write(i + " ");
            Console.WriteLine();    
        }


        static void CalculateCircumAndArea(double r, out double circum, out double area)
        {
            circum = 2 * Math.PI * r;
            area = Math.PI * r * r;  

        }

        // This method attempts to change values of all parameters
        static void ChangeValue(ref int n, string s, Circle c, int[] a)
        {
            n = 100;              // Value type: no effect on original 'num'
            s = "World";          // String (immutable): no effect on original 'str'
            c.Radius = 100;       // Reference type: changes original 'cir.Radius'
            a[0] = 100;           // Reference type: changes original 'arr[0]'
        }
    }
}
