using System;
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
            
            context.InstallModule();
            context.Resolve();
        }
        
        private class ProgramContext
        {
            private DiContainer _container; 
            
            public ProgramContext()
            {
                _container = new DiContainer();
            }

            public void InstallModule()
            {
                _container.Install<ExceptionsHandlerServiceInstaller>();
            }

            public void Resolve()
            {
                _container.Resolve<StartupExceptionHandlersContainer>();
            }
        }
    }
}