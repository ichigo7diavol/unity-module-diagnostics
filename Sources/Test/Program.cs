using System;
using ExceptionsHandlerService.Attributes;
using ExceptionsHandlerService.Containers;
using ExceptionsHandlerService.Installers;
using Zenject;

namespace unity_module_diagnostics
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var context = new ProgramContext();

            try
            {
                context.InstallModule();
                context.Resolve();
                context.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        private class ProgramContext
        {
            private DiContainer _container;
            private TestObject _testObject;
            
            public ProgramContext()
            {
                _container = new DiContainer();
            }

            public void InstallModule()
            {
                _container.Install<ExceptionsHandlerServiceInstaller>();

                _container
                    .BindInterfacesAndSelfTo<TestObject>()
                    .AsSingle();
            }

            public void Resolve()
            {
                _testObject = _container.Resolve<TestObject>();
            }

            public void Execute()
            {
                _testObject.Execute();
            }
        }
    }

    public class StubClassEmpty
    {
    }
    
    public struct StubStructEmpty
    {
    }

    public class StubClass
    {
        private int a;
    }
    
    public struct StubStruct
    {
        private int a;
    }
    
    [Watchable]
    public class WatchableStubClassEmpty
    {
        private int a;
    }
    
    [Watchable]
    public struct WatchableStubStructEmpty
    {
        private int a;
    }
    
    [Watchable]
    public class WatchableStubClass
    {
        private int a;
    }
    
    [Watchable]
    public struct WatchableStubStruct
    {
        public int a;
        public int b;
        public int c;
    }
    
    [Watchable]
    public class WatchableStubClassWitchWatches
    {
        [Watch("int_value")]
        private int a;
    }
    
    [Watchable]
    public struct WatchableStubStructWitchWatches
    {
        [Watch("int_value")]
        private int a;
    }

    [Watchable]
    public interface InterfaceA
    {
        [Watch("A")]
        int __InterA { get; }
    }

    [Watchable]
    public class InheritorB 
        : InterfaceA
    {
        [Watch]
        private int __InherC;
        
        public int __InterA => 1;
    }

    [Watchable]
    public class TestObject
    {
        private readonly StartupExceptionHandlersContainer _exceptionHandlersContainer;
        
        // [Watch("string_value")] 
        // private string _stringValue;
        //
        // [Watch("int_value")] 
        // private int _intValue;
        //
        // [Watch("float_value")] 
        // private float _floatValue;
        //
        // [Watch("StubClass")] 
        // private StubClass[] _StubClass = new StubClass[10];
        //
        // [Watch("StubClass")]
        // private StubClass _StubClass2;

        [Watch("StubClass")] private InterfaceA _inter = new InheritorB();

        public TestObject(StartupExceptionHandlersContainer exceptionHandlersContainer)
        {
            _exceptionHandlersContainer = exceptionHandlersContainer
                ?? throw new ArgumentNullException(nameof(exceptionHandlersContainer));
            
            _exceptionHandlersContainer.PassContext(this);
        }

        public void Execute()
        {
            try
            {
                throw new Exception("TEST");
            }
            catch (Exception e)
            {
                _exceptionHandlersContainer.Handle(e);
            }
        }
    }
}