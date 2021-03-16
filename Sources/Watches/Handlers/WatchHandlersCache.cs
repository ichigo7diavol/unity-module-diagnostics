using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ExceptionsHandlerService.Attributes;
using ExceptionsHandlerService.Exceptions;

namespace ExceptionsHandlerService.Watches
{
    public class WatchHandlersCache
    {
        private const BindingFlags MembersFlag = (BindingFlags) ((long) -1);
		
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
            var watchableAttribute = Attribute.GetCustomAttribute(type, WatchableAttributeType) as WatchableAttribute;
            
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

        private List<IWatchHandler> GetWatchHandlers(Type type)
        {
            var members = type.GetMembers(MembersFlag).ToList();
            var watches = new List<IWatchHandler>();
            
            foreach (var member in members)
            {
                var attribute = Attribute.GetCustomAttribute(member, WatchAttributeType);

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