using System;
using System.Collections.Generic;
using System.Linq;
using ExceptionsHandlerService.Attributes;

namespace ExceptionsHandlerService.Exceptions
{
	public abstract class BaseWatchHandler 
		: IWatchHandler
	{
		protected WatchAttribute Attribute { get; }

		protected abstract bool IsPrimitive { get; }

		protected BaseWatchHandler(WatchAttribute attribute)
		{
			Attribute = attribute ?? throw new ArgumentNullException(nameof(attribute));
		}

		protected virtual IEnumerable<string> GetTransactionalTrace(object contextObject)
		{
			return Enumerable.Empty<string>();
		}

		public abstract WatchData CreateTraceData(object contextObject);
	}
}