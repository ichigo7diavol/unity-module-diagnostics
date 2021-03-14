using System;

namespace ExceptionsHandlerService.Handlers
{
	public interface IExceptionHandler
	{
		void Handle(Exception exception);

		bool IsValid(Exception exception);
	}
}