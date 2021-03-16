using System;
using System.Linq;
using System.Text;

namespace ExceptionsHandlerService.Exceptions
{
    public class ExceptionContextFormatter 
        : IExceptionContextFormatter
    {
        private StringBuilder _sb = new StringBuilder();
        
        public ExceptionContextFormatter()
        {
        }

        public string FormatEntries(IWatchContainerEntry rootEntry)
        {
            if (rootEntry == null)
            {
                throw new ArgumentNullException(nameof(rootEntry));
            }
            _sb.Clear();
            _sb.AppendLine();
            
            ProcessContainerEntry("", rootEntry);
            
            return _sb.ToString();
        }

        private void Process(string prefix, IWatchEntry watch)
        {
            if (watch is IWatchContainerEntry container)
            {
                ProcessContainerEntry(prefix, container);
                
                return;
            }
            ProcessEntry(prefix, watch);
        }

        private void ProcessEntry(string prefix, IWatchEntry entry)
        {
            _sb.AppendLine($"{prefix}{entry.MemberName}:{entry.MemberType} = {entry.AsStringEntry().First()}");
        }

        private void ProcessContainerEntry(string prefix, IWatchContainerEntry container)
        {
            _sb.AppendLine($"{prefix}{container.MemberName}:{container.MemberType.Name} = ");

            foreach (var member in container.ChildMembers)
            {
                Process($"{prefix}\t", member);
            }
        }
    }
}