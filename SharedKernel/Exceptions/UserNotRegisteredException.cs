using System;

namespace SharedKernel.Exceptions
{
	public class UserNotRegisteredException : ApplicationException
	{
		public UserNotRegisteredException()
		{
		}

		public UserNotRegisteredException(string message) : base(message)
		{
		}
	}
}
