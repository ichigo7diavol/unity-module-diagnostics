using System;
using System.Collections.Generic;
using ExceptionsHandlerService.Attributes;

namespace ExceptionsHandlerService.Exceptions
{
	public class HandlersContainer
		: BaseTraceHandlersContainer
	{
		private readonly Type _type;

		private readonly List<ITraceHandler> _tracedMembersCache 
			= new List<ITraceHandler>();
		
		protected override bool IsPrimitive { get; }

		public HandlersContainer(Type type, TraceAttribute attribute) 
			: base(attribute)
		{
			_type = type ?? throw new ArgumentNullException(nameof(type));
			IsPrimitive = false;
		}

		public override TraceData CreateTraceData(object contextObject)
		{
			return new TraceData();
			// return _tracedMembersCache
			// 	.Select(m => m.GetTrace(contextObject))
			// 	.Aggregate((l, r) => l.Concat(r));
		}

		public override void AddMember(ITraceHandler handler)
		{
			_tracedMembersCache.Add(handler);			
		}
	}
}