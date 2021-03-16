using System.Collections.Generic;

namespace DiagnosticsService.Exceptions
{
    public interface IWatchContainerEntry
        : IWatchEntry
    {
        IReadOnlyCollection<IWatchEntry> ChildMembers { get; }

        void AddChild(IWatchEntry child);
    }
}