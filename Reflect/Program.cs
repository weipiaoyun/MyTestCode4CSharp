using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Reflect
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Test AssemblyName, Get Assembly information. Assembly include many class
            //TestAssembly();
            #endregion

            #region Test Class, Class include fields, propertys, funtions, events
            //TestClass();
            #endregion

            #region Test Static Method which has not parameter.
            //TestStaticFunction();
            #endregion

            #region Test Static Method which has parameter.
            //TestStaticFunctionHaveParameter();
            #endregion

            #region Test NonStatic Method
            //TestNonStaticFunction();
            #endregion

            #region  Test the dynamic key 
            dynamic dynamicSample = new Class1();
            //You can't use F12 to go to the execute method. The build just may think you are right. it will check when execute.
            //dynamicSample.TestDynamicKey(12, "parameter1");
            #endregion


            #region  TestDllFileInstanceMethod
            TestDllFileStaticMethod();
            #endregion

            #region  TestDllFileInstanceMethod
            //TestDllFileInstanceMethod();
            #endregion

            Console.ReadLine();


        }


        public static void TestStaticFunction()
        {
            //Defined a type
            Type t = typeof(Class1);
            //Get the Method
            MethodInfo _Info = t.GetMethod("TestStaticFunction");
            if (_Info == null) return;
            //execute the method
            _Info.Invoke(null, null);
        }


        public static void TestStaticFunctionHaveParameter()
        {
            Object any = new Object();
            Class1 obj = new Class1();

            //Defined a type
            Type t = typeof(Class1);
            //Get the Method
            MethodInfo _Info = t.GetMethod("TestStaticFunctionHaveParameter");

            if (_Info == null) return;
            //No matter what the first parameter is. it's ok, but the second parameter must be the same as the method's parameters
            _Info.Invoke(null, new string[] { "test：（StaticWriteString）", "parameter1" });
            _Info.Invoke(obj, new string[] { "test:（StaticWriteString）" });
            _Info.Invoke(any, new string[] { "test:（StaticWriteString）" });
        }

        public static void TestNonStaticFunction()
        {
            Type type = typeof(Class1);
            MethodInfo method = type.GetMethod("TestNonStaticFunction");
            string test = "test";
            int i = 1;
            //parameters array
            Object[] parametors = new Object[] { test, i };
            Class1 obj = new Class1();
            //obj exectude
            method.Invoke(obj, parametors);
        }


        public static void TestAssembly()
        {
            Assembly assem = Assembly.GetExecutingAssembly();
            Console.WriteLine(assem.FullName);
            Console.WriteLine(assem.GetName().Version);
            Console.WriteLine(assem.CodeBase);
            Console.WriteLine(assem.Location);
            Console.WriteLine(assem.EntryPoint);

            Type[] types = assem.GetTypes();
            Console.WriteLine("Include below Class:");
            foreach (var item in types)
            {

                Console.WriteLine("Class：" + item.Name);
            }

        }

        /// <summary>
        /// Get Type information include class's Name, fullName, NameSpace, Assembly,and the class's members
        /// </summary>
        public static void TestClass()
        {
            Type type = typeof(Class1);
            Console.WriteLine("The class name is" + type.Name);
            Console.WriteLine("The class full name is" + type.FullName);
            Console.WriteLine(type.Namespace);
            Console.WriteLine(type.Assembly);
            Console.WriteLine(type.Module);
            //memberInfos include all publice members, like filed, property, event, function ect.
            MemberInfo[] memberInfos = type.GetMembers();

            //Print all Members. include object class's member, like ToString,Equals, GetHashCode, GetType and Ctor
            foreach (var item in memberInfos)
            {
                Console.WriteLine(string.Format("all：{0}:{1}", item.MemberType, item));
            }
        }


        public static void TestDllFileInstanceMethod()
        {

            //Assembly ass;
            Type type;
            string dllPath = AppDomain.CurrentDomain.BaseDirectory;
            Assembly ass = Assembly.LoadFile($"{dllPath}/ClassLibrary.dll");
            //The namespace "ClassLibrary.Class1" and the classnname "Class1" must be wrriten at the same time
            type = ass.GetType("ClassLibrary.Class1");

            MethodInfo method = type.GetMethod("TestNonStaticFunction");
            Object[] parametors = new Object[] { "test", 1 };
            ////The method "TestNonStaticFunction" in the  "ClassLibrary.Class1" is an instance method, so it should create an instance obj to execute.
            //create an instance
            Object obj = ass.CreateInstance("ClassLibrary.Class1");
            //
            method.Invoke(obj, parametors);

            //* the below execute will cause an exception, because the method "TestNonStaticFunction" is an instace method. it must be created an object first.
            Object any = new Object();
            method.Invoke(any, parametors);
        }



        public static void TestDllFileStaticMethod()
        {

            //Assembly ass;
            Type type;
            string dllPath = AppDomain.CurrentDomain.BaseDirectory;
            Assembly ass = Assembly.LoadFile($"{dllPath}/ClassLibrary.dll");
            //The namespace "ClassLibrary.Class1" and the classnname "Class1" must be wrriten at the same time
            type = ass.GetType("ClassLibrary.Class1");

            MethodInfo method = type.GetMethod("TestStaticFunction");
            method.Invoke(null, null);

            //static method which has parameter
            method = type.GetMethod("TestStaticFunctionHaveParameter");
            Object[] parametors = new Object[] { "test", "parameter1" };
            method.Invoke(null, parametors);
        }
    }
}
