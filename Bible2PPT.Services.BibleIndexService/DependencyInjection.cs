using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bible2PPT.Services.BibleIndexService;

public static class DependencyInjection
{
    public static IServiceCollection AddBibleIndexService(
        this IServiceCollection services,
        Action<DbContextOptionsBuilder>? dbContextOptionsAction = null)
    {
        services.AddDbContextFactory<BibleIndexContext>(dbContextOptionsAction);
        services.AddSingleton<BibleIndexService>();
        services.AddScoped<VerseQueryParser>();

        return services;
    }

    // TODO: extend generic host
    public static void UseBibleIndexService(this IServiceProvider serviceProvider)
    {
        Migrate(serviceProvider.GetRequiredService<IDbContextFactory<BibleIndexContext>>());
    }

    private static void Migrate(IDbContextFactory<BibleIndexContext> dbFactory)
    {
        using var db = dbFactory.CreateDbContext();
        db.Database.Migrate();
    }
}
