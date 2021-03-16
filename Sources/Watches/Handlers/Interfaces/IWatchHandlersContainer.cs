using System.Collections.Generic;

namespace ExceptionsHandlerService.Exceptions
{
	public interface IWatchHandlersContainer 
		: IWatchHandler
	{
		void AddMember(IWatchHandler handler);

		IEnumerable<IWatchHandler> GetMembers();
	}
}