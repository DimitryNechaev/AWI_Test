using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartA
{
    // base class to know the exception type for various dependent exceptions
    public class LinkedListException : Exception
    {
    }

    public class LinkedListCircularReferenceException: LinkedListException
    {
    }

    public class LinkedListPossibleCircularReferenceException : LinkedListException
    {
    }
}
