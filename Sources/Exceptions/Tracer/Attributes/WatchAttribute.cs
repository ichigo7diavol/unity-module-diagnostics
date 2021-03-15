using System;

namespace ExceptionsHandlerService.Attributes
{
	[AttributeUsage(AttributeTargets.Field 
		| AttributeTargets.Property 
		| AttributeTargets.Class 
		| AttributeTargets.Struct
		, AllowMultiple = false)
	]
	public class WatchAttribute : Attribute
	{
		public string WatchName { get; }

		public WatchAttribute() { }
		
		public WatchAttribute(string watchName)
		{
			if (string.IsNullOrEmpty(watchName))
			{
				throw new ArgumentNullException(nameof(watchName));
			}
			WatchName = watchName;
		}
	}
}