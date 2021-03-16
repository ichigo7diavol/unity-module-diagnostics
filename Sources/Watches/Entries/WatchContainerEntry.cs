using System;
using System.Collections.Generic;
using System.Linq;

namespace DiagnosticsService.ExceptionContext
{
    public class WatchContainerEntry
        : BaseWatchEntry, IWatchContainerEntry
    {
        public IReadOnlyCollection<IWatchEntry> ChildMembers 
            => _childMembers;

        private List<IWatchEntry> _childMembers = 
            new List<IWatchEntry>();

        public WatchContainerEntry(Type memberType, string memberName) 
            : base(memberType, memberName)
        {
        }
		
        public WatchContainerEntry(Type memberType, string memberName
            , ICollection<IWatchEntry> childs) 
            : base(memberType, memberName)
        {
            if (childs != null)
            {
                _childMembers.AddRange(childs);
            }
        }

        public void AddChild(IWatchEntry child)
        {
            if (child == null)
            {
                throw new ArgumentNullException(nameof(child));
            }
            _childMembers.Add(child);
        }

        public override IEnumerable<string> AsStringEntry()
        {
            return _childMembers.SelectMany(m => m.AsStringEntry());
        }
    }
}