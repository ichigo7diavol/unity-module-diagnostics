using System.Collections.Generic;
using DiagnosticsService.Containers;
using DiagnosticsService.ExceptionContext;
using DiagnosticsService.Handlers;
using DiagnosticsService.Logger;
using DiagnosticsService.Watches;
using Zenject;

namespace DiagnosticsService.Installers
{
	public class DiagnosticsServiceInstaller : Installer
	{
		private readonly IReadOnlyList<System.Type> _baseHandlers
			= new List<System.Type>
			{
				typeof(ExceptionHandler),
				typeof(OverflowHandler),
				typeof(ArgumentNullHandler),
				typeof(ArgumentOutOfRangeHandler),
				typeof(IndexOutOfRangeHandler),
				typeof(KeyNotFoundHandler),
				typeof(NotImplementedHandler),
				typeof(NullReferenceHandler),
				typeof(ObjectDisposedHandler),
			};
		
		public override void InstallBindings()
		{
			BindHandlerContainers();
			BindHandlers();
			InstallFactories();
			BindFormatters();
			BindServices();
		}

		private void BindFormatters()
		{
			Container
				.BindInterfacesAndSelfTo<ExceptionContextFormatter>()
				.AsSingle();
		}

		private void InstallFactories()
		{
			Container
				.BindInterfacesAndSelfTo<ExceptionsContextsFactory>()
				.AsSingle();
			
			Container
				.BindInterfacesAndSelfTo<WatchEntryFactory>()
				.AsSingle();
		}

		private void BindHandlerContainers()
		{
			Container
				.BindInterfacesAndSelfTo<WatchHandlersCache>()
				.AsSingle();
			
			Container
				.BindInterfacesAndSelfTo<PreloaderExceptionHandlersContainer>()
				.AsSingle();
		}

		private void BindHandlers()
		{
			BindBaseExceptionHandlersToHandlersContainer<
				PreloaderExceptionHandlersContainer>();
		}

		private void BindBaseExceptionHandlersToHandlersContainer<T>()
			where T : class, IExceptionHandlersContainer
		{
			foreach (var handlerType in _baseHandlers)
			{
				Container
					.BindInterfacesAndSelfTo(handlerType)
					.AsCached()
					.WhenInjectedInto<T>();	
			}
		}

		private void BindServices()
		{
			Container
				.BindInterfacesAndSelfTo<ConsoleLogger>()
				.AsSingle();
		}
	}
}