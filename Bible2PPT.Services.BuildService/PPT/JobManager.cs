using System.Collections.Concurrent;
using System.Threading.Channels;
using Bible2PPT.Extensions;

namespace Bible2PPT.PPT;

public partial class JobManager
{
    private static readonly int WorkerCount = 1;

    private readonly Task[] _workers;
    private readonly Channel<Job> _jobChannel;
    private readonly ConcurrentDictionary<Job, CancellationTokenSource> _jobCancellationTokenSources = new();

    private IProgress<EventArgs>? _jobProgress;

    public JobManager()
    {
        _jobChannel = Channel.CreateBounded<Job>(new BoundedChannelOptions(WorkerCount)
        {
            FullMode = BoundedChannelFullMode.Wait,
        });
        _workers = Enumerable.Range(1, WorkerCount).Select(_ => RunWorker()).ToArray();
    }

    public void SubscribeJob(IProgress<EventArgs> progress)
    {
        _jobProgress = progress;
    }

    public void Queue(Job job)
    {
        _jobCancellationTokenSources[job] = new CancellationTokenSource();
        OnJobQueued(new JobQueuedEventArgs(job));

        _ = _jobChannel.Writer.WriteAsync(job).AsTask();
    }

    public void Cancel(Job job)
    {
        if (_jobCancellationTokenSources.TryGetValue(job, out var cts))
        {
            cts.CancelIfNotDisposed();
        }
    }

    protected virtual void OnJobQueued(JobQueuedEventArgs e) => _jobProgress?.Report(e);
    protected virtual void OnJobProgress(JobProgressEventArgs e) => _jobProgress?.Report(e);
    protected virtual void OnJobCompleted(JobCompletedEventArgs e) => _jobProgress?.Report(e);

    protected virtual Task ProcessAsync(Job job, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        return Task.CompletedTask;
    }

    private async Task RunWorker()
    {
        await foreach (var job in _jobChannel.Reader.ReadAllAsync().ConfigureAwait(false))
        {
            var cancellationToken = _jobCancellationTokenSources[job].Token;
            try
            {
                await ProcessAsync(job, cancellationToken).ConfigureAwait(false);
                OnJobCompleted(new JobCompletedEventArgs(job));
            }
            catch (Exception ex)
            {
                OnJobCompleted(new JobCompletedEventArgs(job, ex));
            }
            finally
            {
                _jobCancellationTokenSources.TryRemove(job, out var cts);
                using var _ = cts;
            }
        }
    }
}
