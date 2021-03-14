using System;

namespace ExceptionsHandlerService.Logger
{
	public interface ILogger
	{
		void LogMessage(string message);
		void LogWarning(string message);
		void LogError(string message);
		void LogException(Exception exception);
	}
}