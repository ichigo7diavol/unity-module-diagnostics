using System;

namespace ExceptionsHandlerService.Containers
{
	public interface IExceptionHandlersContainer
	{
		void Handle(Exception exception);
	}
}