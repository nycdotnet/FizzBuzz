# FizzBuzz
A .NET implementation of FizzBuzz with NUnit tests.

By default, this library's `Get()` method will return "fizz" when a number is evenly divisible by 3, "buzz" when a number is evenly divisible by 5, and "fizzbuzz" when a number is evenly divisible by both.

Usage:
  * Reference FizzBuzzDotNet.dll in your project.
  * Create a new instance of the `FizzBuzzDotNet.Business.FizzBuzz` class.
  * Enumerate through the results using the `All()` method.
  * Arbitrary FizzBuzz elements can be fetched using the `Get()` method.
  * FizzBuzzDotNet supports removing the default rules and adding new ones.
  * Supports the full range of UInt64 numbers.

Custom Rules:
  A `FizzBuzz` instance supports adding or removing rules via its `Rules` object.  The order of the rules is significant.  It is OK to have more than one rule that applies for a given divisor.
  
**Example:**
```c#

var fb = new FizzBuzz();

fb.Get(30); //fizzbuzz

fb.Rules.Add(new Rule(2, "pop"));

fb.Get(30); //fizzbuzzpop

fb.Rules.Insert(0, new Rule(2, "bang")); //add at first index

fb.Get(30); //bangfizzbuzzpop


```

An example console application is available in the FizzBuzzConsole project.

To test, run NUnit against the `FizzBuzzTests.dll`.
