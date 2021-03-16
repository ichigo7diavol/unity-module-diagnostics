using System;
using DiagnosticsService.Logger;
using DiagnosticsService.Exceptions;

namespace DiagnosticsService.Handlers
{
    public class TestExceptionHandler : BaseExceptionHandler
    {
        public TestExceptionHandler(ILogger logger) 
            : base(logger)
        {
        }

        override public void Handle(Exception exception)
        {
        }

        override public bool IsValid(Exception exception)
        {
            return true;
        }
    }
}