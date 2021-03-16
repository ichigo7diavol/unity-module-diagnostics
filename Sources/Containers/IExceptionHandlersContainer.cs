using System;

namespace DiagnosticsService.Containers
{
	public interface IExceptionHandlersContainer
	{
		void Handle(Exception exception);
		void PassContext(object exception);
	}
}