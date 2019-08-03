using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bible2PPT.Data;

namespace Bible2PPT.PPT
{
    class JobManager : IDisposable
    {
        public event EventHandler<JobAddedEventArgs> JobAdded;
        public event EventHandler<JobProgressEventArgs> JobProgress;
        public event EventHandler<JobCompletedEventArgs> JobCompleted;

        protected virtual void OnJobAdded(JobAddedEventArgs e) => JobAdded?.Invoke(this, e);
        protected virtual void OnJobProgress(JobProgressEventArgs e) => JobProgress?.Invoke(this, e);
        protected virtual void OnJobCompleted(JobCompletedEventArgs e) => JobCompleted?.Invoke(this, e);


        private readonly SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);

        public void Add(Job job)
        {
            using (var db = new BibleContext())
            {
                foreach (var i in job.Bibles)
                {
                    db.Bibles.Attach(i);
                }
                db.Jobs.Add(job);
                db.SaveChanges();
            }

            var cts = new CancellationTokenSource();
            OnJobAdded(new JobAddedEventArgs(job, cts));

            TaskEx.Run(async () =>
            {
                try
                {
                    Semaphore.Wait();

                    cts.Token.ThrowIfCancellationRequested();
                    await ProcessAsync(job, cts);
                }
                catch (Exception ex)
                {
                    OnJobCompleted(new JobCompletedEventArgs(job, ex));
                }
                finally
                {
                    cts.Dispose();
                    Semaphore.Release();
                }
            });
        }

        protected virtual async Task ProcessAsync(Job job, CancellationTokenSource cts) { }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
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
