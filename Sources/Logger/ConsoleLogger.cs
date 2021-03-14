using System;
// using UnityEngine;

namespace ExceptionsHandlerService.Logger
{
	public class ConsoleLogger : ILogger
	{
		public ConsoleLogger()
		{
			//TODO: add log formatter
		}

		public void LogMessage(string message)
		{
			// Debug.Log(message);
		}

		public void LogWarning(string message)
		{
			// Debug.LogWarning(message);
		}

		public void LogError(string message)
		{
			// Debug.LogError(message);
		}

		public void LogException(Exception exception)
		{
			// Debug.LogException(exception);
		}
	}
}