namespace DiagnosticsService.Exceptions
{
    public interface IExceptionContextFormatter
    {
        string FormatEntries(IWatchContainerEntry rootEntry);
    }
}