using System;

namespace DiagnosticsService.Attributes
{
	[AttributeUsage(AttributeTargets.Field 
		| AttributeTargets.Property
		, AllowMultiple = false
		, Inherited = true)
	]
	public class WatchAttribute : Attribute
	{
		public string WatchName { get; }
		public bool IsIgnored { get; }

		public WatchAttribute() { }
		
		public WatchAttribute(string watchName)
		{
			if (string.IsNullOrEmpty(watchName))
			{
				throw new ArgumentNullException(nameof(watchName));
			}
			WatchName = watchName;
		}

		public WatchAttribute(bool isIgnored)
		{
			IsIgnored = isIgnored;
		}
	}
}