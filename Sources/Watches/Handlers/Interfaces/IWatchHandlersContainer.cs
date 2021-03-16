using System.Collections.Generic;

namespace DiagnosticsService.Exceptions
{
	public interface IWatchHandlersContainer 
		: IWatchHandler
	{
		void AddMember(IWatchHandler handler);

		IEnumerable<IWatchHandler> GetMembers();
	}
}