namespace S25W4IntroToGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 5;

            object obj = num; // Boxing, assigning from value-type to reference-type.

            num = (int)obj; // Unboxing, assigning from reference-type to value-type, type casting.

           // if (AreEqual("5.5", "5.5"))
           if (AreEqual<double>(5.5,5.5))
            {
                Console.WriteLine("The values are equal.");
            }
            else
            {
                Console.WriteLine("The values are not equal.");
            }

        }

        // non-generic / normal method
        static bool AreEqual(object value1, object value2)
        {
            return value1.Equals(value2);
        }

        // generic method
        static bool AreEqual<T>(T value1, T value2)
        {
            return value1.Equals(value2);
        }
    }
}
