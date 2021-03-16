using System.Collections.Generic;
using ExceptionsHandlerService.Exceptions;
using ExceptionsHandlerService.Handlers;
using ExceptionsHandlerService.Logger;
using unity_module_diagnostics;

namespace ExceptionsHandlerService.Containers
{
	public class StartupExceptionHandlersContainer 
		: BaseExceptionHandlersContainer<TestObject>
	{
		public StartupExceptionHandlersContainer(ILogger logger
			, List<IExceptionHandler> exceptionsHandlers
			, ExceptionsContextsFactory contextsFactory) 
			: base(logger, exceptionsHandlers, contextsFactory)
		{
		}
	}
}