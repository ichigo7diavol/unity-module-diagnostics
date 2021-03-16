using System;
using System.Collections.Generic;
using System.Linq;
using DiagnosticsService.Attributes;

namespace DiagnosticsService.ExceptionContext
{
	public class ContainerWatchHandler
		: BaseWatchHandlersContainer
	{
		private readonly Type _type;

		private readonly List<IWatchHandler> _watchesCache 
			= new List<IWatchHandler>();

		public override Type Type => _type;

		private string _description;

		public ContainerWatchHandler(Type type, WatchableAttribute attribute) 
			: base(attribute)
		{
			_type = type ?? throw new ArgumentNullException(nameof(type));
			_description = Type.Name;
		}
		
		public ContainerWatchHandler(Type type, string description, WatchableAttribute attribute) 
			: base(attribute)
		{
			_type = type ?? throw new ArgumentNullException(nameof(type));

			_description = string.IsNullOrEmpty(_description)
				? Type.Name
				: description;
		}

		public override WatchData GetWatchData(object contextObject)
		{
			IEnumerable<WatchData> childData = null;

			if (_watchesCache.Any())
			{
				childData = _watchesCache
					.Select(w => w.GetWatchData(contextObject));
			}
			return new WatchData(contextObject, _description, _type, childData);
		}

		override public IEnumerable<IWatchHandler> GetMembers()
		{
			return _watchesCache;
		}

		public override void AddMember(IWatchHandler handler)
		{
			_watchesCache.Add(handler);			
		}
		
		public override void AddMembers(IEnumerable<IWatchHandler> handlers)
		{
			foreach (var handler in handlers)
			{
				_watchesCache.Add(handler);
			}
		}
	}
}