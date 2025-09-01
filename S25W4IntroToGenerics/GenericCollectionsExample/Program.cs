using System.Collections;

namespace GenericCollectionsExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Array
            // Good - Type Safety, Fast Access
            // Bad - Fixed Size, No Built-in Methods for Adding/Removing Elements

            int[] myArray = new int[4];
            myArray[0] = 10;
            myArray[1] = 20;
            myArray[2] = 30;
            myArray[3] = 40;

           //myArray[4] = 50; // This will throw an IndexOutOfRangeException because the array size is fixed at 4.

            int sum = 0;

            for (int i = 0; i < myArray.Length; i++)
            {
                //sum += myArray[i];
                int num = myArray[i];
                sum += num; // Using a variable to hold the value
            }

            Console.WriteLine($"Sum of array elements: {sum}");

            //ArrayList
            // Good - Dynamic Size, Can Store Different Types
            // Bad - No Type Safety, performance issue - Boxing/Unboxing Overhead
            // Do not use the ArrayList, it is not recommended in modern C# programming.

            ArrayList myArrayList = new ArrayList();
            myArrayList.Add(10);
            myArrayList.Add(20);
            myArrayList.Add(30);    
            myArrayList.Add(40);
            //myArrayList.Add("hello"); // Adding a string to an ArrayList

            sum = 0;

            for (int i=0; i<myArrayList.Count; i++)
            {
                int num = (int)myArrayList[i]; // Safe casting
                sum += num; // Using a variable to hold the value
            }
            Console.WriteLine("\nSum = " + sum);

            // List
            List<int> myList = new List<int>(3); // Initial capacity of 3, but it will grow as needed.
            Console.WriteLine(myList.Capacity); // Initial capacity is 0, it will grow as needed.
            myList.Add(10);
            Console.WriteLine(myList.Capacity); // Capacity increases to 4 after adding the first element.
            myList.Add(20);
            myList.Add(30);
            myList.Add(40);
            myList.Add(50); // List will automatically resize to accommodate new elements.
            Console.WriteLine(myList.Capacity); // Capacity increases as needed.

            //myList.Add("hello"); // This will cause a compile-time error because List<int> is type-safe and only accepts integers.

            sum = 0;

            for (int i = 0; i < myList.Count; i++)
            {
                int num = myList[i]; // No casting needed, type-safe
                sum += num; // Using a variable to hold the value
            }
            Console.WriteLine("\nSum of List elements: " + sum);
        }
    }
}
