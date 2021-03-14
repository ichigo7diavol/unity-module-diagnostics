﻿using System.Collections.Generic;
using ExceptionsHandlerService.Containers;
using ExceptionsHandlerService.Handlers;
using ExceptionsHandlerService.Logger;
using Zenject;

namespace ExceptionsHandlerService.Installers
{
	public class ExceptionsHandlerServiceInstaller : Installer
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
			BindServices();
		}

		private void BindContexts()
		{
			// Container
			// 	.BindInterfacesAndSelfTo<StartupExceptionsHandler>()
			// 	.AsSingle();			
		}

		private void BindHandlerContainers()
		{
			Container
				.BindInterfacesAndSelfTo<StartupExceptionHandlersContainer>()
				.AsSingle();
		}

		private void BindHandlers()
		{
			BindBaseExceptionHandlersToHandlersContainer<
				StartupExceptionHandlersContainer>();
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