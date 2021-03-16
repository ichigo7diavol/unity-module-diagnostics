using System;
using System.Collections.Generic;
using ExceptionsHandlerService.Attributes;

namespace ExceptionsHandlerService.Exceptions
{
	public abstract class BaseWatchHandlersContainer
		: IWatchHandler, IWatchHandlersContainer
	{
		private readonly WatchableAttribute _watchableAttribute;

		public abstract Type Type { get; }

		protected BaseWatchHandlersContainer(WatchableAttribute watchableAttribute)
		{
			_watchableAttribute = watchableAttribute 
			    ?? throw new ArgumentNullException(nameof(_watchableAttribute));
		}

		public abstract IEnumerable<IWatchHandler> GetMembers();
		public abstract WatchData GetWatchData(object contextObject);

		public abstract void AddMember(IWatchHandler handler);
		public abstract void AddMembers(IEnumerable<IWatchHandler> handlers);
	}
}