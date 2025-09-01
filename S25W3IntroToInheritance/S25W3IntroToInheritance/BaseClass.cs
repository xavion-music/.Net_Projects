using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S25W3IntroToInheritance
{
    public class BaseClass
    {
        private int myPrivateVar;
        protected int myProtectedVar;
        public int myPublicVar;

        public BaseClass()
        {
            Console.WriteLine("BaseClass constructor called");
        }

        public BaseClass(string msg)
        {
            Console.WriteLine("BaseClass constructor with message called: " + msg);
        }
    }

    public class DerivedClass : BaseClass
    {
        public DerivedClass() : base("Helllloooooo")
        {
            Console.WriteLine("DerivedClass constructor called");
        }
        public void MyMethod()
        {
            // myPrivateVar = 1; // Error: Cannot access private member
            myProtectedVar = 2; // Accessible because it's protected
            myPublicVar = 3; // Accessible because it's public
        }
    }
}
