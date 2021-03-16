using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DiagnosticsService.Attributes;
using DiagnosticsService.Exceptions;

namespace DiagnosticsService.Watches
{
    public class WatchHandlersCache
    {
        private const BindingFlags MembersFlag = (BindingFlags) ((long) -1) ^ BindingFlags.DeclaredOnly;
		
        private readonly Type WatchAttributeType = typeof(WatchAttribute);
        private readonly Type WatchableAttributeType = typeof(WatchableAttribute);
        
        private readonly Dictionary<Type, ContainerWatchHandler> _cache 
            = new Dictionary<Type, ContainerWatchHandler>();

        public ContainerWatchHandler Get(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            
            var watchableAttribute = type.GetCustomAttribute(WatchableAttributeType, true) 
                as WatchableAttribute;
            
            if (watchableAttribute == null)
            {
                return null;
            }
            if (_cache.TryGetValue(type, out var container))
            {
                return container;
            }
            var members = GetWatchHandlers(type);

            if (members == null || !members.Any())
            {
                return null;
            }
            container = CreateHandlersContainer(type, watchableAttribute, members);

            _cache.Add(type, container);

            return container;
        }

        private IEnumerable<MemberInfo> GetMembers(Type type)
        {
            var membersHash = new HashSet<MemberInfo>();

            do
            {
                var members = type.GetMembers(MembersFlag);

                foreach (var member in members)
                {
                    if (!membersHash.Contains(member))
                    {
                        membersHash.Add(member);
                    }
                }
                type = type.BaseType;
            } 
            while (type != null);

            return membersHash;
        }

        private List<IWatchHandler> GetWatchHandlers(Type type)
        {
            var watches = new List<IWatchHandler>();
            var members = GetMembers(type);
            
            foreach (var member in members)
            {
                var attribute = Attribute.GetCustomAttribute(member, WatchAttributeType, true);

                if (attribute == null)
                {
                    continue;
                }
                watches.Add(CreateHandler(member, (WatchAttribute)attribute));
            }
            return watches;
        }

        private IWatchHandler CreateHandler(MemberInfo info, WatchAttribute attribute)
        {
            if (info.MemberType == MemberTypes.Field)
            {
                return new FieldWatchHandler((FieldInfo)info, attribute);
            }
            else if (info.MemberType == MemberTypes.Property)
            {
                return new PropertyWatchHandler((PropertyInfo)info, attribute);
            }
            else
            {
                throw new Exception("Unsupported member type");
            }
        }

        private ContainerWatchHandler CreateHandlersContainer(Type type
            , WatchableAttribute attribute
            , IEnumerable<IWatchHandler> watches)
        {
            var container = new ContainerWatchHandler(type, attribute);

            if (watches != null)
            {
                container.AddMembers(watches);
            }
            return container;
        }
    }
}