using System;

namespace ExceptionsHandlerService.Exceptions
{
	public class WatchEntryFactory
	{
		private readonly ExceptionsContextsFactory _contextsFactory;  
		
		public WatchEntryFactory(ExceptionsContextsFactory contextsFactory)
		{
			_contextsFactory = contextsFactory ?? throw new ArgumentNullException(nameof(contextsFactory));
		}

		public WatchEntry Create(WatchData data)
		{
			return null;
		}
	}
}