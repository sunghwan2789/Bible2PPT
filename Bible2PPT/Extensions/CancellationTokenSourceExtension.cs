using System;
using System.Threading;

namespace Bible2PPT.Extensions
{
    static class CancellationTokenSourceExtension
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
}
