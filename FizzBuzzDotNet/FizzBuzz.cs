using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzDotNet.Business
{
    public class FizzBuzz
    {
        private const UInt64 default_startFrom = 1;
        private const UInt64 default_countTo = 100;

        public readonly UInt64 startFrom;
        public readonly UInt64 countTo;

        // I chose to put countTo before startFrom mostly because I'm assuming
        // that FizzBuzz will usually start from 1.  If it would be common
        // to start from a different number, it might make sense to reverse these,
        // but it would have to be done early on in the project; otherwise it'd create
        // a breaking change that the compiler wouldn't catch.
        public FizzBuzz(UInt64 countTo = default_countTo, UInt64 startFrom = default_startFrom)
        {
            if (countTo < startFrom)
            {
                throw new ArgumentException("FizzBuzz constructor requires countTo value greater than or equal to startFrom value.");
            }
            this.countTo = countTo;
            this.startFrom = startFrom;
        }

        public IEnumerable<string> All()
        {
            for (UInt64 i = startFrom; i <= countTo; i++)
            {
                yield return Get(i);

            }
        }

        public string Get(UInt64 number)
        {
            if (number > countTo || number < startFrom)
            {
                throw new IndexOutOfRangeException(String.Format(
                    "Call to Get() with out of range index {0}.  Only numbers from {1} to {2} are supported with this instance.",
                    number, startFrom, countTo));
            }
            string result = "";
            if (number % 3 == 0)
            {
                result = "fizz";
            }
            if (number % 5 == 0)
            {
                result += "buzz";
            }
            if (string.IsNullOrEmpty(result))
            {
                result = number.ToString();
            }
            return result;
        }
    }
}
