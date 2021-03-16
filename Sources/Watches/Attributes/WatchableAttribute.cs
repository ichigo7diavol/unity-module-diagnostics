using System;

namespace ExceptionsHandlerService.Attributes
{
    [AttributeUsage(AttributeTargets.Class 
                    | AttributeTargets.Struct
                    | AttributeTargets.Interface
        , AllowMultiple = false
        , Inherited = true)
    ]
    public class WatchableAttribute : Attribute
    {
        public WatchableAttribute() { }
    }
}