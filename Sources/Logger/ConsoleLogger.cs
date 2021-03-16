using System;
#if UNITY

using UnityEngine;

#endif

namespace DiagnosticsService.Logger
{
	public class ConsoleLogger : ILogger
	{
		public ConsoleLogger()
		{
		}

		public void LogMessage(string message)
		{
#if UNITY
			Debug.Log(message);
#endif
		}

		public void LogWarning(string message)
		{
#if UNITY
			Debug.LogWarning(message);
#endif
		}

		public void LogError(string message)
		{
#if UNITY
			Debug.LogError(message);
#endif
			
		}

		public void LogException(Exception exception)
		{
#if UNITY
			Debug.LogException(exception);
#endif
		}
	}
}