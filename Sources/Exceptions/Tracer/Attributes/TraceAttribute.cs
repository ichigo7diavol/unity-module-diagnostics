using System;

namespace ExceptionsHandlerService.Attributes
{
	[AttributeUsage(AttributeTargets.Field 
		| AttributeTargets.Property 
		| AttributeTargets.Class 
		| AttributeTargets.Struct
		, AllowMultiple = false)
	]
	public class TraceAttribute : Attribute
	{
		public string TraceName { get; }

		public TraceAttribute() { }
		
		public TraceAttribute(string traceName)
		{
			if (string.IsNullOrEmpty(traceName))
			{
				throw new ArgumentNullException(nameof(traceName));
			}
			TraceName = traceName;
		}
	}
}