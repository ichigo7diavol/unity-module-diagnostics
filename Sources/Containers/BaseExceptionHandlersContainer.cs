using System;
using System.Collections.Generic;
using System.Linq;
using ExceptionsHandlerService.Handlers;
using ExceptionsHandlerService.Logger;

namespace ExceptionsHandlerService.Containers
{
	public abstract class BaseExceptionHandlersContainer 
		: IExceptionHandlersContainer
	{
		protected ILogger Logger { get; }
		
		protected List<IExceptionHandler> ExceptionsHandlers { get; }

		public BaseExceptionHandlersContainer(ILogger logger,
			List<IExceptionHandler> exceptionsHandlers)
		{
			Logger = logger ?? throw new ArgumentNullException(nameof(logger));

			if (exceptionsHandlers == null)
			{
				throw new ArgumentNullException(nameof(exceptionsHandlers));
			}
			ExceptionsHandlers = exceptionsHandlers;
		}

		public void Handle(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException(nameof(exception));
			}
			var handler = ExceptionsHandlers
				.FirstOrDefault(h => h.IsValid(exception));

			if (handler == null)
			{
				HandleDefaultException(exception);

				return;
			}
			handler.Handle(exception);
		}

		protected virtual void HandleDefaultException(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException(nameof(exception));
			}
			throw exception;
		}
	}
}