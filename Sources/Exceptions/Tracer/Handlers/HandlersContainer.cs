using System;
using System.Collections.Generic;
using ExceptionsHandlerService.Attributes;

namespace ExceptionsHandlerService.Exceptions
{
	public class HandlersContainer
		: BaseWatchHandlersContainer
	{
		private readonly Type _type;

		private readonly List<IWatchHandler> _tracedMembersCache 
			= new List<IWatchHandler>();
		
		protected override bool IsPrimitive { get; }

		public HandlersContainer(Type type, WatchAttribute attribute) 
			: base(attribute)
		{
			_type = type ?? throw new ArgumentNullException(nameof(type));
			IsPrimitive = false;
		}

		public override WatchData CreateTraceData(object contextObject)
		{
			return new WatchData();
			// return _tracedMembersCache
			// 	.Select(m => m.GetTrace(contextObject))
			// 	.Aggregate((l, r) => l.Concat(r));
		}

		public override void AddMember(IWatchHandler handler)
		{
			_tracedMembersCache.Add(handler);			
		}
	}
}