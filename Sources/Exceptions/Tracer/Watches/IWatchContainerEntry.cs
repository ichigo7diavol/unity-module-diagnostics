using System.Collections.Generic;

namespace ExceptionsHandlerService.Exceptions
{
    public interface IWatchContainerEntry
        : IWatchEntry
    {
        IReadOnlyCollection<IWatchEntry> ChildMembers { get; }

        void AddChild(IWatchEntry child);
    }
}