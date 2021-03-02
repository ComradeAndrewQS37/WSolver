using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSolver
{
    // something except numbers, variables or operators in formula
    class WrongElementException : Exception
    {
        public WrongElementException(string message)
            : base(message)
        { }
    }

    // formula is not an equation
    class NotEquationException : Exception
    {
        public NotEquationException(string message)
            : base(message)
        { }
    }

    // syntax error in formula (for example missing bracket)
    class SyntaxException : Exception
    {
        public SyntaxException(string message)
            : base(message)
        { }
    }

    // too many roots already found, probably equation has infinite number of roots
    class TooManyRootsException : Exception
    {
        public TooManyRootsException(string message)
            : base(message)
        { }
    }
}
