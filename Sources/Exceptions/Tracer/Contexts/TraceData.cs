using System;

namespace ExceptionsHandlerService.Exceptions
{
	public struct TraceData
	{
		public readonly object MemberValue;
		public readonly string MemberName;
		public readonly Type MemberType;

		public TraceData(object memberValue, string memberName, Type memberType)
		{
			MemberValue = memberValue ?? throw new ArgumentNullException(nameof(memberValue));
			MemberName = memberName ?? throw new ArgumentNullException(nameof(memberName));
			MemberType = memberType ?? throw new ArgumentNullException(nameof(memberType));
		}
	}
}