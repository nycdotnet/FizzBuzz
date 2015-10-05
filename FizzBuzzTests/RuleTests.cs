using System;
using FizzBuzzDotNet.Business;
using NUnit.Framework;


namespace FizzBuzzDotNet
{
    [TestFixture()]
    public class RuleTests
    {
        [Test()]
        public void TestsWorking()
        {
            Assert.AreEqual(1, 1);
        }

        [Test()]
        public void RuleConstructor_GivenArguments_StoresThem()
        {
            var r = new Rule(10,"test");
            Assert.AreEqual(r.divisor, 10);
            Assert.AreEqual(r.substitute, "test");
        }

        [Test()]
        public void Apply_Given10_ReturnsSubstituteOn10_20_5000()
        {
            var r = new Rule(10, "test");
            Assert.AreEqual(r.apply(10), "test");
            Assert.AreEqual(r.apply(20), "test");
            Assert.AreEqual(r.apply(5000), "test");
        }

        [Test()]
        public void Apply_Given10_ReturnsNullOn11_21_5001()
        {
            var r = new Rule(10, "test");
            Assert.IsNull(r.apply(11));
            Assert.IsNull(r.apply(21));
            Assert.IsNull(r.apply(5001));
        }

    }
}
