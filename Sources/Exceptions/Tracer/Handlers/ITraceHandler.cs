namespace ExceptionsHandlerService.Exceptions
{
	public interface ITraceHandler
	{
		TraceData CreateTraceData(object contextObject);
	}
}