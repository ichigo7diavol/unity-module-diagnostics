using System;
using DiagnosticsService.Logger;

namespace DiagnosticsService.Handlers
{
	public class ExceptionHandler 
		: BaseExceptionHandler
	{
		private readonly Type _baseExceptionType = typeof(Exception);
		
		public ExceptionHandler(ILogger logger) 
			: base(logger)
		{
		}

		public override void Handle(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException(nameof(exception));
			}
			throw exception;
		}

		public override bool IsValid(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException(nameof(exception));
			}
			var exceptionType = exception.GetType();
			
			return exceptionType.IsAssignableFrom(_baseExceptionType);
		}
	}
}