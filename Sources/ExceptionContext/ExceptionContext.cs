using System;

namespace DiagnosticsService.ExceptionContext
{
	public class ExceptionContext
	{
		private readonly IWatchContainerEntry _rootEntry;
		private readonly IExceptionContextFormatter _formatter;
		
		public ExceptionContext(IWatchContainerEntry rootEntry, IExceptionContextFormatter formatter)
		{
			_rootEntry = rootEntry;
			_formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
		}

		public string GetContext()
		{
			if (_rootEntry == null)
			{
				return "Root Entry of Watchers is Empty!";
			}
			return _formatter.FormatEntries(_rootEntry);
		}
	}
}