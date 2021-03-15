using ExceptionsHandlerService.Attributes;

namespace ExceptionsHandlerService.Exceptions
{
	public abstract class BaseWatchHandlersContainer
		: BaseWatchHandler, IWatchHandlersContainer
	{
		protected BaseWatchHandlersContainer(WatchAttribute attribute) 
			: base(attribute)
		{
		}

		public abstract void AddMember(IWatchHandler handler);
	}
}