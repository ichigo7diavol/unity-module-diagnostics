using System;

namespace ExceptionsHandlerService.Exceptions
{
	public interface IWatchHandler
	{
		Type Type { get; }
		WatchData GetWatchData(object contextObject);
	}
}