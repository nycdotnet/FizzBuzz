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

    /*
     * Automated test cases. 
     * Provide replacement rules. - extend to support any number of replacement rules. (number and word pairs)
     * put on GitHub and email URL to Rayne
     * 
     */
}
