using System;
using System.Collections.Generic;

namespace DiagnosticsService.Exceptions
{
    public interface IWatchEntry
    {
        Type MemberType { get; }
        string MemberName { get; }

        IEnumerable<string> AsStringEntry();
    }
}