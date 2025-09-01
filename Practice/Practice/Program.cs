namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is the answer of 5+10: ");
            int ans = int.Parse(Console.ReadLine());
            if (ans == 15)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect, the answer is 15.");
            }
        }
    }
}
