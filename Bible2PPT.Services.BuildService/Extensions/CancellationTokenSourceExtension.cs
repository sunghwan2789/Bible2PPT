namespace Bible2PPT.Extensions;

public static class CancellationTokenSourceExtension
{
    public static void CancelIfNotDisposed(this CancellationTokenSource cts)
    {
        try
        {
            cts.Cancel();
        }
        catch (ObjectDisposedException) { }
    }
}
