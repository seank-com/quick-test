using System;

namespace quick_test
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime departure = new DateTime(2010, 6, 12, 18, 32, 22, 105);
            DateTime arrival = new DateTime(2010, 6, 13, 18, 32, 22, 725);
            TimeSpan travelTime = arrival - departure;  
            Console.WriteLine($"{arrival} - {departure} = {travelTime}");               
            Console.WriteLine(travelTime.ToString());
        }
    }
}
