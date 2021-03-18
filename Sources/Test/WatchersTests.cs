using System;
using System.Collections.Generic;
using System.Linq;
using DiagnosticsService.Attributes;
using DiagnosticsService.Containers;
using DiagnosticsService.ExceptionContext;
using DiagnosticsService.Installers;
using NUnit.Framework;
using Zenject;

namespace unity_module_diagnostics.Tests
{
    #region TEST_CLASSES

    public class StubClassEmpty
    {
    }

    public class StubClass
    {
        private int a;
    }

    [Watchable]
    public class WatchableStubClassEmpty
    {
        private int a;
    }

    [Watchable]
    public class WatchableStubClass
    {
        private int a;
    }

    [Watchable]
    public class WatchableStubClassWitchWatches
    {
        [Watch("int_value")]
        private int a;
    }

    #endregion
    
    #region TEST_STRUCTS
    
    public struct StubStructEmpty
    {
    }
    
    public struct StubStruct
    {
        private int a;
    }
    
    [Watchable]
    public struct WatchableStubStructEmpty
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
    public struct WatchableStubStructWitchWatches
    {
        [Watch("int_value")]
        private int a;
    }
    
    #endregion
    
    [Watchable]
    public interface WatchableInterface
    {
        [Watch("A")]
        int _inheritedIntPropertyWatch { get; }
    }

    [Watchable]
    public class WatchableInheritor 
        : WatchableInterface
    {
        [Watch]
        private int _intValueWatch;

        public int _inheritedIntPropertyWatch => 0;
    }

    // [Watchable]
    // public class WatchableTestClass
    // {
    //     private readonly StartupExceptionHandlersContainer _exceptionHandlersContainer;
    //
    //     [Watch("StubClass")] 
    //     private WatchableInterface _inter = new WatchableInheritor();
    //
    //     public WatchableTestClass(StartupExceptionHandlersContainer exceptionHandlersContainer)
    //     {
    //         _exceptionHandlersContainer = exceptionHandlersContainer
    //                                       ?? throw new ArgumentNullException(nameof(exceptionHandlersContainer));
    //         
    //         _exceptionHandlersContainer.PassContext(this);
    //     }
    //
    //     public void Execute()
    //     {
    //         try
    //         {
    //             throw new Exception("TEST");
    //         }
    //         catch (Exception e)
    //         {
    //             _exceptionHandlersContainer.Handle(e);
    //         }
    //     }
    // }
    
    public class TestContext
    {
        private DiContainer _container;

        public ExceptionsContextsFactory CtxFactory { private set; get; }

        public TestContext()
        {
            _container = new DiContainer();
        }

        public void InstallModule()
        {
            _container.Install<DiagnosticsServiceInstaller>();
        }

        public void Resolve()
        {
            CtxFactory = _container
                .Resolve<ExceptionsContextsFactory>();
        }
    }
    
    [TestFixture]
    public class WatchersTests
    {
        private TestContext _context; 
        
        private class EmptyClass
        {
        }
        
        private class EmptyStruct
        {
        }

        [SetUp]
        public void Setup()
        {
            _context = new TestContext();
            
            _context.InstallModule();
            _context.Resolve();
        }

        private class EmptyClassAndStructContext
        {
            private EmptyClass _emptyClass = new EmptyClass();
            private EmptyClass _emptyStruct = new EmptyClass();
        }

        [Test()]
        public void EmptyClassAndStructTest()
        {
            var context = _context.CtxFactory.Create(new EmptyClassAndStructContext());
            
            Assert.NotNull(context, "Context can't be NULL even Watchable Object does not has any watchers!");

            context.RootEntry.ChildMembers.Map(e => e, )
            
            foreach (var VARIABLE in context.RootEntry.ChildMembers)
            {
                
            }
        }
    }

    public static class LINQExtensions
    {
        public static IEnumerable<TSource> Map<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> selectorFunction,
            Func<TSource, IEnumerable<TSource>> getChildrenFunction)
        {
            // Add what we have to the stack
            var flattenedList = source.Where(selectorFunction);

            // Go through the input enumerable looking for children,
            // and add those if we have them
            foreach (TSource element in source)
            {
                flattenedList = flattenedList
                    .Concat(getChildrenFunction(element)
                        .Map(selectorFunction, getChildrenFunction)
                );
            }
            return flattenedList;
        }
    }
}