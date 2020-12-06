using System;

namespace ncburn.TwitterStroller.Service.Exceptions
{
	public class InvalidCodePointException : Exception
	{
		public InvalidCodePointException(string message) : base(message)
		{
		}

		public InvalidCodePointException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
