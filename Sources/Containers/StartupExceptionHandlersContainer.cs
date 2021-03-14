using System.Collections.Generic;
using ExceptionsHandlerService.Handlers;
using ExceptionsHandlerService.Logger;

namespace ExceptionsHandlerService.Containers
{
	public class StartupExceptionHandlersContainer 
		: BaseExceptionHandlersContainer
	{
		public StartupExceptionHandlersContainer(ILogger logger
			, List<IExceptionHandler> exceptionsHandlers) 
			: base(logger, exceptionsHandlers)
		{
		}
	}
}