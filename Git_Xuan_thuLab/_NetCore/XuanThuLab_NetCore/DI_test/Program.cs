using System;
using Microsoft.Extensions.DependencyInjection;

namespace DI_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var services = new ServiceCollection();
            //services.AddSingleton<IPerson, SV>();
            //var serviceprovider = services.BuildServiceProvider();
            //IPerson sv= serviceprovider.GetService<IPerson>();
            //Console.WriteLine("Out: " + sv.GetName());
            //

        }
    }


    interface IPerson
    {
        public string GetName();
    }
    public class Student : IPerson
    {
        private string Name;
        public Student(IOption)
        {
            this.Name = name;
        }
        public string GetName() =>"Student: "+ Name;
    }
    public class SV : IPerson
    {
        private string Name;
        //public SV(string name)
        //{
        //    this.Name = name;
        //}
        public string GetName() => "SV: "+ Name;
    }
}
