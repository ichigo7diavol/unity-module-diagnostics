using System;

namespace ExceptionsHandlerService.Attributes
{
    [AttributeUsage(AttributeTargets.Class 
                    | AttributeTargets.Struct
        , AllowMultiple = false)
    ]
    public class WatchableAttribute : Attribute
    {
        public WatchableAttribute() { }
    }
}