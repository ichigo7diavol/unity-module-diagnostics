using System;
using System.Collections.Generic;

namespace DiagnosticsService.ExceptionContext
{
    public interface IWatchEntry
    {
        Type MemberType { get; }
        string MemberName { get; }

        IEnumerable<string> AsStringEntry();
    }
}