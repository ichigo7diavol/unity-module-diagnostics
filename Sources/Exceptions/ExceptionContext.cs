using System;

namespace ExceptionsHandlerService.Exceptions
{
	public class ExceptionContext
	{
		private readonly IWatchContainerEntry _rootEntry;
		private readonly IExceptionContextFormatter _formatter;
		
		public ExceptionContext(IWatchContainerEntry rootEntry, IExceptionContextFormatter formatter)
		{
			_rootEntry = rootEntry ?? throw new ArgumentNullException(nameof(rootEntry));
			_formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
		}

		public string GetContext()
		{
			return _formatter.FormatEntries(_rootEntry);
		}
	}
}