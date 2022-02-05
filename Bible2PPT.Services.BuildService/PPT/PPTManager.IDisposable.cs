namespace Bible2PPT.PPT;

public partial class PPTManager : IDisposable
{
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            WorkingPPT?.Close();
        }
    }
}
