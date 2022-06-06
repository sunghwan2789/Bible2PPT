using System.Text;
using Bible2PPT.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bible2PPT.Services.BibleService;

public static class DependencyInjection
{
    public static IServiceCollection AddBibleService(
        this IServiceCollection services,
        Action<DbContextOptionsBuilder>? dbContextOptionsAction = null)
    {
        services.AddDbContextFactory<BibleContext>(dbContextOptionsAction);
        services.AddSingleton<BibleService>();
        services.AddSingleton<ZippedBibleService>();

        return services;
    }

    // TODO: extend generic host
    public static void UseBibleService(this IServiceProvider serviceProvider)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Migrate(serviceProvider.GetRequiredService<IDbContextFactory<BibleContext>>());
    }

    private static void Migrate(IDbContextFactory<BibleContext> dbFactory)
    {
        using var db = dbFactory.CreateDbContext();
        db.Database.Migrate();
    }
}
