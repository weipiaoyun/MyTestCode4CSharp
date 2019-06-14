using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Class1
    {
        public static void TestStaticFunction()
        {
	    Console.WriteLine("Static function is exectued");
        }

        public static void TestStaticFunctionHaveParameter(string parameter, string parameter1)
        {

	    Console.WriteLine(parameter);
	    Console.WriteLine(parameter1);
        }


        public void TestNonStaticFunction(string parameter, int parameter1)
        {
	    Console.WriteLine($"TestNonStaticFunction which has two parameters, the one is {parameter}, the other is {parameter1}");
        }

        public void TestDynamicKey()
        {


	    Console.WriteLine("TestDynamic is executed");
        }

        public void TestDynamicKey(int parameter, string parameter1)
        {


	    Console.WriteLine("TestDynamic is executed");
        }
    }
}
