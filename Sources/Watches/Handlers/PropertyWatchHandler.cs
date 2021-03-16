using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DiagnosticsService.Attributes;

namespace DiagnosticsService.ExceptionContext
{
	public class PropertyWatchHandler 
		: BaseWatchHandler
	{
		private readonly PropertyInfo _info;

		protected override bool IsGeneric { get; }

		public override Type Type => _info.PropertyType;

		public PropertyWatchHandler(PropertyInfo info, WatchAttribute attribute)
			: base(attribute)
		{
			_info = info ?? throw new ArgumentNullException(nameof(info));

			IsGeneric = _info.PropertyType.Assembly.GetName().Name != "System";
		}

		public override WatchData GetWatchData(object contextObject)
		{
			return new WatchData
			(
				_info.GetValue(contextObject), 
				_info.Name, 
				_info.PropertyType
			);
		}
	}
}