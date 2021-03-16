using System.Collections.Generic;
using DiagnosticsService.Exceptions;
using DiagnosticsService.Handlers;
using DiagnosticsService.Logger;
using unity_module_diagnostics;

namespace DiagnosticsService.Containers
{
	public class StartupExceptionHandlersContainer 
		: BaseExceptionHandlersContainer
	{
		public StartupExceptionHandlersContainer(ILogger logger
			, List<IExceptionHandler> exceptionsHandlers
			, ExceptionsContextsFactory contextsFactory) 
			: base(logger, exceptionsHandlers, contextsFactory)
		{
		}
	}
}