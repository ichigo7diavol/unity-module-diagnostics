namespace ExceptionsHandlerService.Exceptions
{
	public interface IWatchHandler
	{
		WatchData CreateTraceData(object contextObject);
	}
}