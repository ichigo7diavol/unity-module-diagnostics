namespace ExceptionsHandlerService.Exceptions
{
	public interface IWatchHandlersContainer 
		: IWatchHandler
	{
		void AddMember(IWatchHandler handler);
	}
}