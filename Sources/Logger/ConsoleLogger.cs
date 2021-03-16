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
#if UNITY
#endif
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

		public class ConsoleAppLogger : ILogger
		{
			public ConsoleAppLogger()
			{
			}

			public void LogMessage(string message)
			{
				Console.WriteLine(message);
			}

			public void LogWarning(string message)
			{
				Console.WriteLine(message);
			}

			public void LogError(string message)
			{
				Console.WriteLine(message);
			}

			public void LogException(Exception exception)
			{
				Console.WriteLine(exception);
			}
		}
	}
}