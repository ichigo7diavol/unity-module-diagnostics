using System;

namespace DiagnosticsService.ExceptionContext
{
	public class ExceptionsContextsFactory
	{
		private readonly WatchEntryFactory _entriesFactory;
		private readonly IExceptionContextFormatter _formatter;

		public ExceptionsContextsFactory(WatchEntryFactory entriesFactory, IExceptionContextFormatter formatter)
		{
			_entriesFactory = entriesFactory ?? throw new ArgumentNullException(nameof(entriesFactory));
			_formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
		}

		public ExceptionContext Create<T>(T contextualObject)
			where T : class
		{
			var type = typeof(T);

			var root = _entriesFactory.CreateRootEntry(type, contextualObject);

			return new ExceptionContext(root, _formatter);
		}
	}
}