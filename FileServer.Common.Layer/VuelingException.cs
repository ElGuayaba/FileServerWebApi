using System;

namespace FileServer.Common.Layer
{ 
	public class VuelingException : Exception
	{
		public VuelingException()
		{
		}

		public VuelingException(string message)
			: base(message)
		{
		}

		public VuelingException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
