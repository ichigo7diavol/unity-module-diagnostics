using System;
using DiagnosticsService.Logger;

namespace DiagnosticsService.Handlers
{
	public abstract class BaseExceptionHandler 
		: IExceptionHandler
	{
		protected ILogger Logger { get; }

		public BaseExceptionHandler(ILogger logger)
		{
			Logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public abstract void Handle(Exception exception);
		public abstract bool IsValid(Exception exception);
	}
}