namespace ListExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee(101, "Palak C", "100000");
            Employee emp2 = new Employee(102, "Jeff L", "120000");
            Employee emp3 = new Employee(103, "Sally F", "150000");

            List<Employee> employees = new List<Employee>();
            employees.Add(emp1);
            employees.Add(emp2);
            employees.Add(emp3);

            employees.Insert(1, emp3);
            employees.Remove(emp3); // Remove by object reference   
            //employees.Clear(); // Clear the list

            var e = employees[2];
            Console.WriteLine("Employee at index 2: \n" + e);

            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }

            //searching a List

            //IndexOf()
            int index = employees.IndexOf(emp2);

            if (index >= 0)
                Console.WriteLine("Item exists \n\n");
            else
                Console.WriteLine("Item does not exist \n\n");

            //Contains()
            if (employees.Contains(emp2))
            {
                Console.WriteLine("Item exists \n\n");
            }
            else
            {
                Console.WriteLine("Item does not exist \n\n");
            }

            //Exists
            if (employees.Exists(e => e.Name.StartsWith("S")))
            
                    Console.WriteLine("Item exists \n\n");
            else
                Console.WriteLine("Item does not exist \n\n");

            //Find
            var em = employees.Find(e => e.Salary > 1000000);

            if (em != null)
            {
                Console.WriteLine("Item exists \n\n" + em);
            }
            else
            {
                Console.WriteLine("Item does not exist \n\n");
            }


        }
    }
}
