using System;
using System.Reflection;
using ExceptionsHandlerService.Attributes;

namespace ExceptionsHandlerService.Exceptions
{
	public class FieldHandler 
		: BaseWatchHandler
	{
		private readonly FieldInfo _info;

		protected override bool IsPrimitive { get; }

		public FieldHandler(FieldInfo info, WatchAttribute attribute)
			: base(attribute)
		{
			_info = info ?? throw new ArgumentNullException(nameof(info));
			
			IsPrimitive = _info.FieldType.Assembly.GetName().Name == "System";
		}

		public override WatchData CreateTraceData(object contextObject)
		{
			return new WatchData
			(
				_info.GetValue(contextObject),
				_info.Name,
				_info.FieldType
			);
		}
	}
}