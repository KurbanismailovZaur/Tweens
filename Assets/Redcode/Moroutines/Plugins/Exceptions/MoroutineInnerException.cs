using System;

namespace Redcode.Moroutines.Exceptions
{
    public class MoroutineInnerException : ApplicationException
    {
        public MoroutineInnerException(string message, Exception inner) : base(message, inner) { }
    }
}