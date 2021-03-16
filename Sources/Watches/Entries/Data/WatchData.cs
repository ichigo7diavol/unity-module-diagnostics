using System;
using System.Collections.Generic;
using System.Linq;

namespace ExceptionsHandlerService.Exceptions
{
	public class WatchData
	{
		public readonly object MemberValue;
		public readonly string MemberName;
		
		public readonly Type MemberType;
		public readonly IReadOnlyCollection<WatchData> ChildData;

		public bool IsAnyChildData => ChildData != null && ChildData.Any();
		
		public WatchData(object memberValue, string memberName, 
			Type memberType)
		{
			MemberValue = memberValue;
			MemberName  = memberName  ?? throw new ArgumentNullException(nameof(memberName));
			MemberType  = memberType  ?? throw new ArgumentNullException(nameof(memberType));
		}
		
		public WatchData(object memberValue, string memberName, 
			Type memberType, IEnumerable<WatchData> childData)
		{
			if (childData != null)
			{
				ChildData = childData.ToList();
			}
			MemberValue = memberValue;
			MemberName  = memberName  ?? throw new ArgumentNullException(nameof(memberName));
			MemberType  = memberType  ?? throw new ArgumentNullException(nameof(memberType));
		}
	}
}