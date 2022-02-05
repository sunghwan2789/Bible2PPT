using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bible2PPT.Services.BuildService;

public static class DependencyInjection
{
    public static IServiceCollection AddBuildService(
        this IServiceCollection services,
        Action<DbContextOptionsBuilder>? dbContextOptionsAction = null,
        Action<Exception>? interopInitializeErrorAction = null)
    {
        services.AddDbContextFactory<BuildContext>(dbContextOptionsAction);
        services.AddSingleton<HiddenPowerPoint>(_ =>
        {
            try
            {
                return new HiddenPowerPoint();
            }
            catch (Exception ex)
            {
                interopInitializeErrorAction?.Invoke(ex);
                throw;
            }
        });
        services.AddTransient<PPT.Builder>();

        return services;
    }

    public static void UseBuildService(this IServiceProvider serviceProvider)
    {
        Migrate(serviceProvider.GetRequiredService<IDbContextFactory<BuildContext>>());
    }

    private static void Migrate(IDbContextFactory<BuildContext> dbFactory)
    {
        using var db = dbFactory.CreateDbContext();
        db.Database.EnsureCreated();
    }
}
