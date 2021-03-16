using System;
using System.Collections.Generic;
using System.Linq;

namespace DiagnosticsService.Exceptions
{
	public class WatchEntry
		: BaseWatchEntry
	{
		public string Value { get; }

		public WatchEntry(Type memberType, string memberName, string value)
			: base(memberType, memberName)
		{
			Value = string.IsNullOrEmpty(value) 
				? throw new ArgumentNullException(nameof(value)) 
				: value;
		}

		public override IEnumerable<string> AsStringEntry()
		{
			return Enumerable.Empty<string>().Append(Value);
		}
	}
}