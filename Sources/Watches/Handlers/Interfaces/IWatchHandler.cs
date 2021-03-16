using System;

namespace DiagnosticsService.Exceptions
{
	public interface IWatchHandler
	{
		Type Type { get; }
		WatchData GetWatchData(object contextObject);
	}
}