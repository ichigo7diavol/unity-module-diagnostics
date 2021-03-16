using System;

namespace DiagnosticsService.ExceptionContext
{
	public interface IWatchHandler
	{
		Type Type { get; }
		WatchData GetWatchData(object contextObject);
	}
}