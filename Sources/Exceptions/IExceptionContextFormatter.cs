namespace ExceptionsHandlerService.Exceptions
{
    public interface IExceptionContextFormatter
    {
        string FormatEntries(IWatchContainerEntry rootEntry);
    }
}