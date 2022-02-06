using Microsoft.Extensions.DependencyInjection;

namespace Bible2PPT.Services.TemplateService;

public static class DependencyInjection
{
    public static IServiceCollection AddTemplateService(this IServiceCollection services)
    {
        services.AddSingleton<TemplateService>();

        return services;
    }
}
