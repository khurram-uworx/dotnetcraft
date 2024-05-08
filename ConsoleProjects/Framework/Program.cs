using System;

namespace Framework
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            string location;
            DateTime time;

            Console.WriteLine(location == null ? "location is null" : location);
            Console.WriteLine(time == null ? "time is null" : time.ToString());

            Console.WriteLine("Finished, press Enter to exit");
            Console.ReadLine();
        }
    }
}
