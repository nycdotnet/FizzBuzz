﻿using System;
using System.Collections.Generic;
using FizzBuzzDotNet.Business;
using NUnit.Framework;


namespace FizzBuzzDotNet
{
    [TestFixture()]
    public class FizzBuzzTests
    {
        [Test()]
        public void TestsWorking()
        {
            Assert.AreEqual(1,1);
        }

        [Test()]
        public void FizzBuzzConstructor_GivenNoArguments_WillCountFrom1To100()
        {
            var fb = new FizzBuzz();
            Assert.AreEqual(1, fb.startFrom);
            Assert.AreEqual(100, fb.countTo);
        }

        [Test()]
        public void FizzBuzzConstructor_GivenOneArgument200_WillCountFrom1To200()
        {
            var fb = new FizzBuzz(200);
            Assert.AreEqual(1, fb.startFrom);
            Assert.AreEqual(200, fb.countTo);
        }

        [Test()]
        public void FizzBuzzConstructor_GivenTwoArguments300And5_WillCountFrom5To300()
        {
            var fb = new FizzBuzz(300,5);
            Assert.AreEqual(5, fb.startFrom);
            Assert.AreEqual(300, fb.countTo);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException),
            ExpectedMessage = "requires countTo value greater than or equal to",
            MatchType = MessageMatch.Contains)]
        public void FizzBuzzConstructor_GivenCountToLessThanStartFrom_ThrowsException()
        {
            var fb = new FizzBuzz(1, 2);
        }

        [Test()]
        public void Get_GivenUInt64MaxAppropriately_WillReturnCorrectResult()
        {
            var fb = new FizzBuzz(UInt64.MaxValue);
            Assert.AreEqual("fizzbuzz", fb.Get(UInt64.MaxValue));
        }

        [Test()]
        public void Get_GivenZeroAppropriately_WillReturnCorrectResult()
        {
            var fb = new FizzBuzz(1,0);
            Assert.AreEqual("fizzbuzz", fb.Get(0));
        }

        [Test()]
        public void Get_WithDefaultRulesAnd1_Returns1()
        {
            var fb = new FizzBuzz();
            Assert.AreEqual("1", fb.Get(1));
        }

        [Test()]
        public void Get_WithDefaultRulesAnd3_ReturnsFizz()
        {
            var fb = new FizzBuzz();
            Assert.AreEqual("fizz", fb.Get(3));
        }

        [Test()]
        public void Get_WithDefaultRulesAnd5_ReturnsBuzz()
        {
            var fb = new FizzBuzz();
            Assert.AreEqual("buzz", fb.Get(5));
        }

        [Test()]
        public void Get_WithDefaultRulesAnd15_ReturnsFizzBuzz()
        {
            var fb = new FizzBuzz();
            Assert.AreEqual("fizzbuzz", fb.Get(15));
        }

        [Test()]
        public void Get_WithDefaultRulesAndCountToValue_ReturnsFizzBuzz()
        {
            var fb = new FizzBuzz();
            Assert.AreEqual("buzz", fb.Get(fb.countTo), "expected that the countTo value (which should be the top bound) would return a valid string result.");
        }

        [Test()]
        public void Get_WithNewApplicableRuleAtEnd_ReturnsFizzBuzzPop()
        {
            var fb = new FizzBuzz();
            fb.Rules.Add(new Rule(2, "pop"));
            Assert.AreEqual("fizzbuzzpop", fb.Get(30));
        }
        
        [Test()]
        public void Get_WithNewApplicableRuleInsertedAtStart_ReturnsPopFizzBuzz()
        {
            var fb = new FizzBuzz();
            fb.Rules.Insert(0, new Rule(2, "pop"));
            Assert.AreEqual("popfizzbuzz", fb.Get(30));
        }

        [Test()]
        public void Get_WithNewApplicableDuplicateRuleAtEnd_ReturnsFizzBuzzPopBang()
        {
            var fb = new FizzBuzz();
            fb.Rules.Add(new Rule(2, "pop"));
            fb.Rules.Add(new Rule(2, "bang"));
            Assert.AreEqual("fizzbuzzpopbang", fb.Get(30), "Expected both 'duplicate' rules to apply.");
        }

        [Test()]
        public void Get_WhenRulesHaveBeenCleared_AlwaysReturnsTheNumber()
        {
            var fb = new FizzBuzz(15);
            fb.Rules.Clear();

            for (UInt64 i = 1; i <= fb.countTo; i++)
            {
                Assert.AreEqual(i.ToString(), fb.Get(i));
            }
        }
        
        [Test()]
        [ExpectedException(typeof(IndexOutOfRangeException),
            ExpectedMessage = "out of range index 0.",
            MatchType = MessageMatch.Contains)]
        public void Get_GivenValueLessThanStartFrom_ThrowsException()
        {
            var fb = new FizzBuzz();
            fb.Get(0);
        }

        [Test()]
        [ExpectedException(typeof(IndexOutOfRangeException),
            ExpectedMessage = "out of range index 101.",
            MatchType = MessageMatch.Contains)]
        public void Get_GivenValueGreaterThanCountTo_ThrowsException()
        {
            var fb = new FizzBuzz();
            fb.Get(101);
        }

    }
}
