using Bible2PPT.Extensions;

namespace Bible2PPT.PPT;

public partial class JobManager : IAsyncDisposable
{
    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore().ConfigureAwait(false);

        // Dispose(false);
        GC.SuppressFinalize(this);
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        _jobChannel.Writer.Complete();
        foreach (var cts in _jobCancellationTokenSources.Values)
        {
            cts.CancelIfNotDisposed();
            using var _ = cts;
        }
        await Task.WhenAll(_workers).ConfigureAwait(false);
    }
}
