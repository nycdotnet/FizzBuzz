using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzDotNet
{
    public class Rule
    {
        public UInt64 divisor {get; set;}
        public string substitute { get; set; }
        
        public Rule(UInt64 divisor, string substitute)
        {
            this.divisor = divisor;
            this.substitute = substitute;
        }
        
        public string apply(UInt64 number) {
            if (number % divisor == 0)
            {
                return substitute;
            }
            return null;
        }
    }
}
