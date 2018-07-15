using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartA;

namespace PartATest
{
    [TestClass]
    public class UnitTest1
    {
        // return first item of the list of N
        LinkedListItem GenerateList(int n)
        {
            LinkedListItem result = null;
            LinkedListItem prev = null;

            for (int i = 1; i <= n; i++)
            {
                var item = new LinkedListItem()
                {
                    Value = i
                };

                if (i > 1)
                    prev.Next = item;
                else
                    result = item;

                prev = item;
            }

            return result;
        }

        [TestMethod]
        public void TestFunctionalRequirement()
        {
            // 2 -> 3 -> 4 ->5 -> 6 -> 7 -> 8 -> 9 -> 10 -> 11
            var entry = GenerateList(11).Next;
            // your function would return 7
            var element = LinkedListHelper.Get5thElementFromTheTail(entry);
            Assert.IsNotNull(element);
            Assert.AreEqual(element.Value, 7);
        }

        [TestMethod]
        public void TestVariants()
        {
            var rnd = new Random();
            var variants = new int[]
            {
                3, 5, 11, rnd.Next(10, 99), rnd.Next(100, 999)
            };

            foreach (var variant in variants)
            {
                var entry = GenerateList(variant);
                var element = LinkedListHelper.Get5thElementFromTheTail(entry);
                if (variant < 5)
                {
                    Assert.IsNull(element);
                }
                else
                {
                    Assert.IsNotNull(element);
                    Assert.AreEqual(element.Value, variant - 4);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(LinkedListCircularReferenceException))]
        public void TestExplicitCircularReferenceException()
        {
            var entry = GenerateList(5);

            // make closed loop
            var last = entry;
            while (last.Next != null) last = last.Next;
            last.Next = entry;

            LinkedListHelper.Get5thElementFromTheTail(entry);
        }

        [TestMethod]
        [ExpectedException(typeof(LinkedListPossibleCircularReferenceException))]
        public void TestPossibleCircularReferenceException()
        {
            var entry = GenerateList(3);

            // make closed loop
            var last = entry;
            while (last.Next != null) last = last.Next;
            last.Next = entry.Next;

            LinkedListHelper.Get5thElementFromTheTail(entry);
        }


    }
}
