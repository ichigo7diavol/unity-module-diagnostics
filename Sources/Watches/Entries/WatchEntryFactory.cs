using System;
using System.Collections.Generic;
using System.Linq;
using DiagnosticsService.Watches;

namespace DiagnosticsService.Exceptions
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
			var rootHandler = _cache.Get(contextualObject.GetType());
			var data = rootHandler.GetWatchData(contextualObject);
			
			return CreateContainerEntry(data);
		}
		
		private IWatchEntry Create(WatchData data)
		{
			var containerWatchHandler = _cache.Get(data.MemberValue?.GetType() ?? data.MemberType);
			
			if (containerWatchHandler != null)
			{
				return CreateRootEntry(containerWatchHandler.Type, data.MemberValue);
			}
			return CreateEntry(data);
		}

		//TODO: delegate values check
		private IWatchEntry CreateEntry(WatchData data)
		{
			var value = data.MemberType.IsClass && !(data.MemberValue is string)
				? data.MemberValue == null
					? "NULL"
					: data.MemberValue.GetType().Name
				: data.MemberValue.ToString();
			
			return new WatchEntry(data.MemberType, data.MemberName, value);
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