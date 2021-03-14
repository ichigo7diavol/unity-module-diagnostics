using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ExceptionsHandlerService.Attributes;

namespace ExceptionsHandlerService.Exceptions
{
	public class ExceptionsContextsFactory
	{
		private const BindingFlags MembersFlag = (BindingFlags) ((long) -1);
		
		private readonly Type TracingAttribute = typeof(TraceAttribute);
		
		private readonly Dictionary<Type, HandlersContainer> _cache 
			= new Dictionary<Type, HandlersContainer>();

		public IReadOnlyDictionary<Type, HandlersContainer> Cache => _cache; 
		
		public ExceptionContext Create<T>(T contextualObject)
			where T : class
		{
			var type = typeof(T);

			var members = GetMembers(type);

			return null;
		}

		private List<MemberInfo> GetMembers(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException(nameof(type));
			}
			var members = type.GetMembers(MembersFlag);

			var attributes = members
				.Select(m => Attribute.GetCustomAttribute(m, TracingAttribute))
				.Where(a => a != null)
				.Cast<TraceAttribute>();
			
			// attributes.First().

			return null;
		}
	}
}