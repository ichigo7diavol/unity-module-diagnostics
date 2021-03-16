using System;

namespace DiagnosticsService.Handlers
{
	public interface IExceptionHandler
	{
		void Handle(Exception exception);

		bool IsValid(Exception exception);
	}
}