using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Bible2PPT.Extensions;

namespace Bible2PPT.PPT
{
    class JobManager : IDisposable
    {
        public IProgress<EventArgs> JobProgress { get; set; }

        protected virtual void OnJobQueued(JobQueuedEventArgs e) => JobProgress?.Report(e);
        protected virtual void OnJobProgress(JobProgressEventArgs e) => JobProgress?.Report(e);
        protected virtual void OnJobCompleted(JobCompletedEventArgs e) => JobProgress?.Report(e);


        private readonly SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);
        private readonly ConcurrentDictionary<Job, CancellationTokenSource> JobCancellations = new ConcurrentDictionary<Job, CancellationTokenSource>();

        [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "just log")]
        public void Queue(Job job)
        {
            JobCancellations[job] = new CancellationTokenSource();
            OnJobQueued(new JobQueuedEventArgs(job));

            Task.Run(async () =>
            {
                var acquired = false;
                try
                {
                    Semaphore.Wait(JobCancellations[job].Token);
                    acquired = true;
                    await ProcessAsync(job, JobCancellations[job].Token).ConfigureAwait(false);
                    OnJobCompleted(new JobCompletedEventArgs(job, null));
                }
                catch (Exception ex)
                {
                    OnJobCompleted(new JobCompletedEventArgs(job, ex));
                }
                finally
                {
                    JobCancellations.TryRemove(job, out var cts);
                    cts.Dispose();
                    if (acquired)
                    {
                        Semaphore.Release();
                    }
                }
            });
        }

        public void Cancel(Job job)
        {
            if (JobCancellations.TryGetValue(job, out var cts))
            {
                cts.CancelIfNotDisposed();
            }
        }

        protected virtual Task ProcessAsync(Job job, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            return Task.CompletedTask;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    foreach (var pair in JobCancellations)
                    {
                        Cancel(pair.Key);
                    }
                    Semaphore.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~JobManager()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
