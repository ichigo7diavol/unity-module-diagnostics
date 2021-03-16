using System;
using System.Collections.Generic;

namespace ExceptionsHandlerService.Exceptions
{
    public interface IWatchEntry
    {
        Type MemberType { get; }
        string MemberName { get; }

        IEnumerable<string> AsStringEntry();
    }
}