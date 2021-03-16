using System;
using DiagnosticsService.Attributes;

namespace DiagnosticsService.ExceptionContext
{
	public abstract class BaseWatchHandler 
		: IWatchHandler
	{
		protected WatchAttribute Attribute { get; }

		protected abstract bool IsGeneric { get; }

		public abstract Type Type { get; }

		protected BaseWatchHandler(WatchAttribute attribute)
		{
			Attribute = attribute ?? throw new ArgumentNullException(nameof(attribute));
		}

		public abstract WatchData GetWatchData(object contextObject);
	}
}