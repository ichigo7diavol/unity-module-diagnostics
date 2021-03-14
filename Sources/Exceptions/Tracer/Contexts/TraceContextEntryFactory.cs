using System;

namespace ExceptionsHandlerService.Exceptions
{
	public class TraceContextEntryFactory
	{
		private readonly ExceptionsContextsFactory _contextsFactory;  
		
		public TraceContextEntryFactory(ExceptionsContextsFactory contextsFactory)
		{
			_contextsFactory = contextsFactory ?? throw new ArgumentNullException(nameof(contextsFactory));
		}

		public TraceContextEntry Create(TraceData data)
		{
			return null;
		}
	}
}