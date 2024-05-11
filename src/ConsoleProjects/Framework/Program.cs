using System;
using UWorx.DotNet;             // explicit using
using static System.Console;    // using static methods

namespace Framework
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Person? p = NullableHelper.MayBePerson();

            if (null != p)              // check for null OR if you know this is not null use null forgiving
                WriteLine(p.FirstName); //p!.LastName   null forgiving


            WriteLine("Finished, press Enter to exit");
            ReadLine();

            Console.WriteLine("Finished, press Enter to exit");
            Console.ReadLine();
        }
    }
}
