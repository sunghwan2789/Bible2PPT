using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace Bible2PPT.PPT
{
    using Element = Tuple<Work, CancellationToken, IProgress<BuildProgress>>;

    class Builder
    {

        private static PowerPoint.Application POWERPNT;

        public Builder()
        {
            if (POWERPNT == null)
            {
                POWERPNT = new PowerPoint.Application();
                try
                {
                    POWERPNT.Visible = MsoTriState.msoFalse;
                }
                catch { }
            }
        }

        private readonly ConcurrentQueue<Element> Queue = new ConcurrentQueue<Element>();

        private SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public void Push(Work work, CancellationToken cancellationToken, IProgress<BuildProgress> progress, IProgress<BuildResult> end)
        {
            Queue.Enqueue(Tuple.Create(work, cancellationToken, progress));
            TaskEx.Run(async () =>
            {
                try
                {
                    semaphore.Wait(cancellationToken);
                    while (Queue.TryDequeue(out var item))
                    {
                        if (item.Item2.IsCancellationRequested)
                        {
                            continue;
                        }

                        end.Report(await DoWorkAsync(item.Item1, item.Item2, item.Item3));
                        break;
                    }
                }
                catch { }
                finally
                {
                    semaphore.Release();
                }
            });
        }

        private async Task<BuildResult> DoWorkAsync(Work work, CancellationToken cancellationToken, IProgress<BuildProgress> progress)
        {

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
                    try
                    {
                        if (POWERPNT != null && POWERPNT.Presentations.Count == 0)
                        {
                            POWERPNT.Quit();
                            POWERPNT = null;
                        }
                    }
                    catch { }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~PPTBuilder() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
