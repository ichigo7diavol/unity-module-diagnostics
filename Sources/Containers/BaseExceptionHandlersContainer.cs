using System;
using System.Collections.Generic;
using System.Linq;
using DiagnosticsService.Exceptions;
using DiagnosticsService.Handlers;
using DiagnosticsService.Logger;

namespace DiagnosticsService.Containers
{
	public abstract class BaseExceptionHandlersContainer
		: IExceptionHandlersContainer
	{
		private readonly ExceptionsContextsFactory _contextsFactory;
		private object _contextualObject;
		
		protected ILogger Logger { get; }
		
		protected List<IExceptionHandler> ExceptionsHandlers { get; }

		public BaseExceptionHandlersContainer(ILogger logger
			, List<IExceptionHandler> exceptionsHandlers
			, ExceptionsContextsFactory contextsFactory)
		{
			Logger = logger 
			    ?? throw new ArgumentNullException(nameof(logger));

			_contextsFactory = contextsFactory 
			                   ?? throw new ArgumentNullException(nameof(contextsFactory));

			ExceptionsHandlers = exceptionsHandlers 
			    ?? throw new ArgumentNullException(nameof(exceptionsHandlers));
		}

		public void PassContext(object contextualObject)
		{
			_contextualObject = contextualObject
			    ?? throw new ArgumentNullException(nameof(contextualObject));
		}

		public void Handle(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException(nameof(exception));
			}
			if (_contextualObject == null)
			{
				throw new Exception("Context are not initialized!");
			}
			var handler = ExceptionsHandlers
				.FirstOrDefault(h => h.IsValid(exception));

			try
			{
				if (handler == null)
				{
					HandleDefaultException(exception);

					return;
				}
				handler.Handle(exception);
			}
			catch (Exception e)
			{
				var context = _contextsFactory.Create(_contextualObject);
				
				throw new Exception(context.GetContext(), e);
			}
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