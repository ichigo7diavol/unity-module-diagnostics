namespace DiagnosticsService.ExceptionContext
{
    public interface IExceptionContextFormatter
    {
        string FormatEntries(IWatchContainerEntry rootEntry);
    }
}