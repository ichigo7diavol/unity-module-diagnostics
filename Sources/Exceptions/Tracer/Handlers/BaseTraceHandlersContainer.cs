using ExceptionsHandlerService.Attributes;

namespace ExceptionsHandlerService.Exceptions
{
	public abstract class BaseTraceHandlersContainer
		: BaseTraceHandler, ITraceHandlersContainer
	{
		protected BaseTraceHandlersContainer(TraceAttribute attribute) 
			: base(attribute)
		{
		}

		public abstract void AddMember(ITraceHandler handler);
	}
}