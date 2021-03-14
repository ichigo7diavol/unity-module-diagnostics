using System;
using System.Reflection;
using ExceptionsHandlerService.Attributes;

namespace ExceptionsHandlerService.Exceptions
{
	public class FieldHandler 
		: BaseTraceHandler
	{
		private readonly FieldInfo _info;

		protected override bool IsPrimitive { get; }

		public FieldHandler(FieldInfo info, TraceAttribute attribute)
			: base(attribute)
		{
			_info = info ?? throw new ArgumentNullException(nameof(info));
			
			IsPrimitive = _info.FieldType.Assembly.GetName().Name == "System";
		}

		public override TraceData CreateTraceData(object contextObject)
		{
			return new TraceData
			(
				_info.GetValue(contextObject),
				_info.Name,
				_info.FieldType
			);
		}
	}
}