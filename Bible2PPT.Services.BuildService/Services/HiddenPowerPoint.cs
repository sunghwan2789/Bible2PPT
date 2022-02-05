using Microsoft.Office.Interop.PowerPoint;

namespace Bible2PPT.Services;

public class HiddenPowerPoint : IDisposable
{
    public Application Instance { get; private set; }

    public HiddenPowerPoint()
    {
        Instance = new Application();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (Instance.Presentations.Count == 0)
            {
                Instance.Quit();
            }
            Instance = null;
        }
    }
}
