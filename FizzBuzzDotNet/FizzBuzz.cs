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
        
        private List<Rule> rules;
        public IList<Rule> Rules
        {
            get {
                return rules;
            }
        }

        // I chose to place countTo before startFrom mostly because I'm assuming
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
            this.rules = (List<Rule>)FizzBuzz.DefaultRules();
        }

        public static IList<Rule> DefaultRules()
        {
            List<Rule> rules = new List<Rule>() {
                new Rule(3, "fizz"),
                new Rule(5, "buzz")
            };
            
            return rules;
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

            var substitutions = new List<string>();

            foreach (var rule in rules) {
                string substitute = rule.apply(number);
                if (!String.IsNullOrEmpty(substitute))
                {
                    substitutions.Add(substitute);
                }
            }

            if (substitutions.Any())
            {
                return String.Join("", substitutions);
            }

            return number.ToString();

        }
    }
}
