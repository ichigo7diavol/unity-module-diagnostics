using System;
using System.Collections.Generic;
using System.Linq;
using ExceptionsHandlerService.Attributes;

namespace ExceptionsHandlerService.Exceptions
{
	public abstract class BaseTraceHandler 
		: ITraceHandler
	{
		protected TraceAttribute Attribute { get; }

		protected abstract bool IsPrimitive { get; }

		protected BaseTraceHandler(TraceAttribute attribute)
		{
			Attribute = attribute ?? throw new ArgumentNullException(nameof(attribute));
		}

		protected virtual IEnumerable<string> GetTransactionalTrace(object contextObject)
		{
			return Enumerable.Empty<string>();
		}

		public abstract TraceData CreateTraceData(object contextObject);
	}
}