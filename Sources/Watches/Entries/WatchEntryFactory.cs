using System;
using System.Collections.Generic;
using System.Linq;
using ExceptionsHandlerService.Watches;

namespace ExceptionsHandlerService.Exceptions
{
	public class WatchEntryFactory
	{
		private readonly WatchHandlersCache _cache;  
		
		public WatchEntryFactory(WatchHandlersCache handlersCache)
		{
			_cache = handlersCache 
			    ?? throw new ArgumentNullException(nameof(handlersCache));
		}

		public IWatchContainerEntry CreateRootEntry(Type type, object contextualObject)
		{
			var rootHandler = _cache.Get(type);
			var data = rootHandler.GetWatchData(contextualObject);
			
			return CreateContainerEntry(data);
		}
		
		private IWatchEntry Create(WatchData data)
		{
			if (data.IsAnyChildData)
			{
				return CreateContainerEntry(data);
			}
			return CreateEntry(data);
		}

		private IWatchEntry CreateEntry(WatchData data)
		{
			return new WatchEntry(data.MemberType, data.MemberName, data.MemberValue?.ToString() ?? "NULL");
		}

		private IWatchContainerEntry CreateContainerEntry(WatchData data)
		{
			ICollection<IWatchEntry> childEntries = null;
				
			if (data.IsAnyChildData)
			{
				childEntries = data.ChildData
					.Select(Create)
					.ToList();
			}
			return new WatchContainerEntry(data.MemberType, data.MemberName, childEntries);
		}
	}
}