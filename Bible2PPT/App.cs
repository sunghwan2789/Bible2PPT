using Microsoft.Maui.Hosting;

namespace Bible2PPT;

public class App : CometApp
{
    [Body]
    View view() => new MainPage();

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseCometApp<App>();
#if DEBUG
        builder.EnableHotReload();
#endif
        return builder.Build();
    }
}
