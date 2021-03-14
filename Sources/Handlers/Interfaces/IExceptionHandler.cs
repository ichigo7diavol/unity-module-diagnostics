using System;

namespace ExceptionsHandlerService.Handlers
{
	public interface IExceptionHandler
	{
		public void Handle(Exception exception);

		public bool IsValid(Exception exception);
	}
}