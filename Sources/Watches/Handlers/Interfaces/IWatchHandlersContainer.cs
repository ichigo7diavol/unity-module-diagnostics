using System.Collections.Generic;

namespace DiagnosticsService.ExceptionContext
{
	public interface IWatchHandlersContainer 
		: IWatchHandler
	{
		void AddMember(IWatchHandler handler);

		IEnumerable<IWatchHandler> GetMembers();
	}
}