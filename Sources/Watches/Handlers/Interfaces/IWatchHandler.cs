namespace ExceptionsHandlerService.Exceptions
{
	public interface IWatchHandler
	{
		WatchData GetWatchData(object contextObject);
	}
}