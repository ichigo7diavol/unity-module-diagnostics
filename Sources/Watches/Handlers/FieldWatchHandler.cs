using System;
using System.Reflection;
using DiagnosticsService.Attributes;

namespace DiagnosticsService.Exceptions
{
	public class FieldWatchHandler 
		: BaseWatchHandler
	{
		private readonly FieldInfo _info;

		protected override bool IsGeneric { get; }

		public override Type Type => _info.FieldType;
		
		public FieldWatchHandler(FieldInfo info, WatchAttribute attribute)
			: base(attribute)
		{
			_info = info ?? throw new ArgumentNullException(nameof(info));
			
			IsGeneric = _info.FieldType.Assembly.GetName().Name != "System";
		}

		public override WatchData GetWatchData(object contextObject)
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