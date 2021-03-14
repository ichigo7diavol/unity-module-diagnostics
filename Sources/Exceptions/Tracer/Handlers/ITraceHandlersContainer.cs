namespace ExceptionsHandlerService.Exceptions
{
	public interface ITraceHandlersContainer 
		: ITraceHandler
	{
		void AddMember(ITraceHandler handler);
	}
}