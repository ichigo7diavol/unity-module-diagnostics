using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ExceptionsHandlerService.Attributes;

namespace ExceptionsHandlerService.Exceptions
{
	public class PropertyHandler 
		: BaseWatchHandler
	{
		private readonly PropertyInfo _info;

		protected override bool IsPrimitive { get; }

		public PropertyHandler(PropertyInfo info, WatchAttribute attribute)
			: base(attribute)
		{
			_info = info ?? throw new ArgumentNullException(nameof(info));

			IsPrimitive = _info.PropertyType.Assembly.GetName().Name == "System";
		}

		public override WatchData CreateTraceData(object contextObject)
		{
			return new WatchData
			(
				_info.GetValue(contextObject), 
				_info.Name, 
				_info.PropertyType
			);
			// return Enumerable
			// 	.Empty<string>()
			// 	.Append(_info.GetValue(contextObject).ToString());
		}
	}
}