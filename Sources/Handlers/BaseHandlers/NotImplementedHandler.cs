using System;
using DiagnosticsService.Logger;

namespace DiagnosticsService.Handlers
{
	public class NotImplementedHandler 
		: BaseExceptionHandler
	{
		public NotImplementedHandler(ILogger logger) 
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
			return exception is NotImplementedException;
		}
	}
}