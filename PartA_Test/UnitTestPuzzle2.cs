using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartA;

namespace PartATest
{
    [TestClass]
    public class UnitTestPuzzle2
    {
        [TestMethod]
        public void TestFunctionalRequirement()
        {
            var result = WordReverseHelper.ReverseWholeWords("Cat and dog");
            Assert.AreEqual(result, "taC dna god");
        }


        [TestMethod]
        public void TestVariants()
        {
            var variants = new Dictionary<string, string>()
            {
                { "cat", "tac" },
                { "123 456 7890", "321 654 0987"},
                { "   123   4   ", "   321   4   " },
                { "123   ", "321   " },
                { "   123", "   321" },
            };
            foreach (var variant in variants)
            {
                // check reversing
                var reversed = WordReverseHelper.ReverseWholeWords(variant.Key);
                Assert.AreEqual(reversed, variant.Value);
                // check double reversing
                reversed = WordReverseHelper.ReverseWholeWords(reversed);
                Assert.AreEqual(reversed, variant.Key);
            }
            

        }
    }
}
