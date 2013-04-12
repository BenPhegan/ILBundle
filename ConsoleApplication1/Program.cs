using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ResourceAssemblyLoader.RegisterAssemblyResolver();
            var test = new TestClass();
            test.Main();
        }


    }

    public class TestClass
    {
        public void Main()
        {
            Console.WriteLine("Hello");
            Console.ReadLine();
        }
    }
}
