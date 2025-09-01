namespace S25W3IntroToInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* //Console.WriteLine("Hello, World!");
             BaseClass objBase = new BaseClass();
             //objBase.myPrivateVar = 1; // Error: Cannot access private member
             //objBase.myProtectedVar = 2; // Error: Cannot access protected member
             objBase.myPublicVar = 3; // Accessible because it's public

             DerivedClass objDerived = new DerivedClass();
             objDerived.myPublicVar = 4; // Accessible because it's public
             //objDerived.myPrivateVar = 5; // Error: Cannot access private member 
             //objDerived.myProtectedVar = 6; // Error: Cannot access protected member*/

            //BaseClass objBaseDerived = new BaseClass();
            //DerivedClass objDerived = new DerivedClass();

            CommissionEmployee commEmp = new CommissionEmployee(1, "Palak", 10000, 0.15);
            Console.WriteLine(commEmp);
            Console.WriteLine($"\nEarnings: {commEmp.Earnings():C}\n\n");

            SalaryPlusCommissionEmployee salCommEmp = new SalaryPlusCommissionEmployee(2, "Anne", 8000, 0.10, 500);
            Console.WriteLine(salCommEmp);
            Console.WriteLine($"\nEarnings: {salCommEmp.Earnings():C}\n\n");
        }
    }
}
