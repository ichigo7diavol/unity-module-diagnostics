using System.Collections.Generic;
using DiagnosticsService.ExceptionContext;
using DiagnosticsService.Handlers;
using DiagnosticsService.Logger;

namespace DiagnosticsService.Containers
{
	public class PreloaderExceptionHandlersContainer 
		: BaseExceptionHandlersContainer
	{
		public PreloaderExceptionHandlersContainer(ILogger logger
			, List<IExceptionHandler> exceptionsHandlers
			, ExceptionsContextsFactory contextsFactory) 
			: base(logger, exceptionsHandlers, contextsFactory)
		{
		}
	}
}