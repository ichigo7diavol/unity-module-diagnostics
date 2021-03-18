using System;

namespace DiagnosticsService.ExceptionContext
{
	public class ExceptionContext
	{
		private readonly IExceptionContextFormatter _formatter;
		public IWatchContainerEntry RootEntry { get; }

		public ExceptionContext(IWatchContainerEntry rootEntry, IExceptionContextFormatter formatter)
		{
			RootEntry = rootEntry;
			_formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
		}

		public string GetContext()
		{
			if (RootEntry == null)
			{
				return "Root Entry of Watchers is Empty!";
			}
			return _formatter.FormatEntries(RootEntry);
		}
	}
}