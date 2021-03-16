using System.Collections.Generic;

namespace DiagnosticsService.ExceptionContext
{
    public interface IWatchContainerEntry
        : IWatchEntry
    {
        IReadOnlyCollection<IWatchEntry> ChildMembers { get; }

        void AddChild(IWatchEntry child);
    }
}