using System;

namespace Moroutines.Exceptions
{
	public class PlayControlException : ApplicationException
	{
		public PlayControlException(string message) : base(message) { }
	}
}