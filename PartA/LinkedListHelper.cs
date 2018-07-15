using System;
using System.Text;
using System.Threading.Tasks;

namespace PartA
{
    public static class LinkedListHelper
    {
        /// <summary>
        /// Return the Nth element from the tail.
        /// This algoryhm is not perfect for large N. It will consume N*4 (x32) or N*8 (x64) bytes of memory.
        /// </summary>
        /// <param name="item">Any entry point into the list</param>
        /// <param name="n">Items to count back from the end</param>
        /// <param name="maxListLength">Expected max length of the list, default 1000</param>
        /// <returns>Nth element from the tail, or null if list is shorter than N elements</returns>
        internal static LinkedListItem GetNthElementFromTheTail(LinkedListItem item, int n, int maxListLength = 1000)
        {
            // protect against getting into endless loop
            // this is simplified check which only cares that we don't meed entry element flollowing the list
            // if there is a closed loop after the entry element, it will rely on maxListLength to detect it
            //  (entry 1 -> 2 -> 3 -> 1) = explicit circular dependency error
            //  (entry 1 -> 2 -> 3 -> 2) = implicit due go over the max expected list length
            var checkpoint = item;

            // this is the stack of the last N elements
            var lastN = new LinkedListItem[n];
            var pointer = 0;

            while (item != null)
            {
                // replace latest in the stack with the value
                lastN[pointer % n] = item;
                // stack pointer -> {0..n-1}
                pointer++;

                item = item.Next;
                if (item == checkpoint)
                    throw new LinkedListCircularReferenceException();

                if (pointer > maxListLength)
                    throw new LinkedListPossibleCircularReferenceException();
            }

            // return item remembered n turns ago
            // or null if we had less then n items in the list
            return pointer < n ? null : lastN[(pointer - n) % n];
        }

        /// <summary>
        /// Return 5th element from the tail of singly linked list
        /// </summary>
        /// <param name="item">An entry point to the list</param>
        /// <returns>5th element from the tail or nothing in case of a list shorter then 5</returns>
        public static LinkedListItem Get5thElementFromTheTail(LinkedListItem item)
        {
            return GetNthElementFromTheTail(item, 5);
        }
    }
}
