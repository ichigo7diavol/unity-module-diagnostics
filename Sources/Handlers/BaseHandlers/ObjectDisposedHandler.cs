using System;
using ExceptionsHandlerService.Logger;

namespace ExceptionsHandlerService.Handlers
{
	public class ObjectDisposedHandler 
		: BaseExceptionHandler
	{
		public ObjectDisposedHandler(ILogger logger) 
			: base(logger)
		{
		}

		public override void Handle(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException(nameof(exception));
			}
		}

		public override bool IsValid(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException(nameof(exception));
			}
			return exception is ObjectDisposedException;
		}
	}
}