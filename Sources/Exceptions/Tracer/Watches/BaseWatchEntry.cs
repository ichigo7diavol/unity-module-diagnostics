using System;
using System.Collections.Generic;

namespace ExceptionsHandlerService.Exceptions
{
    public abstract class BaseWatchEntry
        : IWatchEntry
    {
        public Type MemberType { get; }
        public string MemberName { get; }

        protected BaseWatchEntry(Type memberType, string memberName)
        {
            MemberType = memberType ?? throw new ArgumentNullException(nameof(memberType));
			
            MemberName = string.IsNullOrEmpty(memberName) 
                ? throw new ArgumentNullException(nameof(memberName)) 
                : memberName;
        }

        public abstract IEnumerable<string> GetValue();
    }
}