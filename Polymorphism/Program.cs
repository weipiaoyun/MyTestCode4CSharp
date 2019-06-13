using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {

            //Parent parent = new Parent();
            //parent.show();

            #region  Test constructor. when defined a child object, it will not only execute the child's constructor but also the parent's constructor
            //Child child = new Child();
            //child.show();

            #endregion

            #region Test two Parameters in constructor
            //Child childHavePara = new Child("This is the first parameter", "This is the second parameter");
            //childHavePara.show();
            #endregion


            #region  Test the "new"  key, in this case, the "parent1.show()" will excute the parent's show. 
            ////No matter  whether the "new" key is added, the result is the same.
            //Parent parent = new Child();
            //parent.show();
            #endregion

            #region  Test the "override"  key, in this case, the "parent.show()" will execute the child's show
            //show child
            //Parent parent = new Child();
            //parent.showTestOverride();
            //Parent parentOverride = new Child();
            #endregion

            Console.ReadLine();

        }

    }


    public class Parent
    {
        public Parent()
        {
            Console.WriteLine("Parent's Constructor");
        }

        public Parent(string parameter1)
        {
            Console.WriteLine($"Parent's constructorc which has one parameter");
        }

        public Parent(string parameter1, string parameters2)
        {
            Console.WriteLine($"Parent's constructor which has two parameters");
        }

        public virtual void show()
        {
            Console.WriteLine("Executing parent's function 'show'");
        }

        public virtual void showTestOverride()
        {
            Console.WriteLine("ParentOverride");
        }

    }

    public class Child : Parent
    {
        public Child()
        {
            Console.WriteLine("Child constructor");
        }

        //The base keyword is used in the derived class that decides  which parent constuctor will be invoded
        //There are two parameters after the "base" below.so it will invode the parent constructor which has tow parameters.
        public Child(string param1, string param2) : base(param1, param2)
        {

            Console.WriteLine($"Child constructor which have two parameters {param1} {param2}");
        }


        //in this case, add new and doesnot add is the same result
        public new void show()
        {
            Console.WriteLine("Execute child' function 'show()'");
        }

        //Override keyword is used in the derived class of the base class in order to override the base class method.
        public override void showTestOverride()
        {
            Console.WriteLine("ChildOverride");
        }
    }

    public class Child1 : Child
    {
        //public new void show()
        //{
        //    Console.WriteLine("Child");
        //}
    }
}
