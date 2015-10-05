using System;
using FizzBuzzDotNet.Business;

namespace FizzBuzzDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var fb = new FizzBuzz(2000000000);
            foreach (var item in fb.All())
            {
                Console.WriteLine(item);
            };
            Console.ReadKey();
        }
    }

}
