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
        public void TestVariants()
        {
            var variants = new int[]
            {
                10, 100, 100
            };

            foreach (var variant in variants)
            {
                var entry = GenerateList(variant);
                var element = LinkedListHelper.Get5thElementFromTheTail(entry);
                Assert.IsNotNull(element);
                Assert.AreEqual(element.Value, variant - 5);
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
