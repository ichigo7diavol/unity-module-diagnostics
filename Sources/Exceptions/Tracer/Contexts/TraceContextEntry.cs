using System;
using System.Collections.Generic;
using System.Linq;

namespace ExceptionsHandlerService.Exceptions
{
	public interface ITraceContextEntry
	{
		Type MemberType { get; }
		string MemberName { get; }

		IEnumerable<string> GetValue();
	}

	public interface ITraceContextContainerEntry
		: ITraceContextEntry
	{
		IReadOnlyCollection<ITraceContextEntry> ChildMembers { get; }

		void AddChild(ITraceContextEntry child);
	}

	public abstract class BaseTraceContextEntry
		: ITraceContextEntry
	{
		public Type MemberType { get; }
		public string MemberName { get; }

		protected BaseTraceContextEntry(Type memberType, string memberName)
		{
			MemberType = memberType ?? throw new ArgumentNullException(nameof(memberType));
			
			MemberName = string.IsNullOrEmpty(memberName) 
				? throw new ArgumentNullException(nameof(memberName)) 
				: memberName;
		}

		public abstract IEnumerable<string> GetValue();
	}

	public class TraceContextEntry
		: BaseTraceContextEntry
	{
		public string Value { get; }

		public TraceContextEntry(Type memberType, string memberName, string value)
			: base(memberType, memberName)
		{
			Value = string.IsNullOrEmpty(value) 
				? throw new ArgumentNullException(nameof(value)) 
				: value;
		}

		public override IEnumerable<string> GetValue()
		{
			return Enumerable.Empty<string>().Append(Value);
		}
	}

	public class TraceContextContainerEntry
		: BaseTraceContextEntry, ITraceContextContainerEntry
	{
		public IReadOnlyCollection<ITraceContextEntry> ChildMembers 
			=> _childMembers;

		private List<ITraceContextEntry> _childMembers = 
			new List<ITraceContextEntry>();

		public TraceContextContainerEntry(Type memberType, string memberName) 
			: base(memberType, memberName)
		{
		}
		
		public TraceContextContainerEntry(Type memberType, string memberName
			, ICollection<ITraceContextEntry> childs) 
			: base(memberType, memberName)
		{
			if (childs == null) throw new ArgumentNullException(nameof(childs));
			
			_childMembers.AddRange(childs);
		}

		public void AddChild(ITraceContextEntry child)
		{
			if (child == null)
			{
				throw new ArgumentNullException(nameof(child));
			}
			_childMembers.Add(child);
		}

		public override IEnumerable<string> GetValue()
		{
			return _childMembers.SelectMany(m => m.GetValue());
		}
	}
}