using System;
using System.Collections.Generic;
using DiagnosticsService.Logger;

namespace DiagnosticsService.Handlers
{
	public class KeyNotFoundHandler 
		: BaseExceptionHandler
	{
		public KeyNotFoundHandler(ILogger logger)
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
			return exception is KeyNotFoundException;
		}
	}
}