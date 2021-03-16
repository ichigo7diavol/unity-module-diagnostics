using System;

namespace DiagnosticsService.ExceptionContext
{
	// TODO: rename
	public class HandlerContextException : Exception
	{
		public HandlerContextException(ExceptionContext context)
			: base()
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

		}
		
		public HandlerContextException(ExceptionContext context, string message)
			: base(message)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}
		}

		public HandlerContextException(ExceptionContext context, string message, Exception innerException)
			: base(message, innerException)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}
		}
	}
}