using Microsoft.Extensions.DependencyInjection;

namespace Sharemee.DevelopKit.Network;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebApiRequest(this IServiceCollection services, Action<WebApiRequestOptions> configure)
    {
        var options = new WebApiRequestOptions();
        configure(options);

        services.Configure(configure);

        services.AddHttpClient(options.Name, httpClient =>
        {
            httpClient.BaseAddress = new Uri(options.Domain);
            if (options.Timeout.HasValue)
            {
                httpClient.Timeout = TimeSpan.FromSeconds(options.Timeout.Value);
            }
        });

        services.AddTransient<IHttpRequest, WebApiRequest>();

        return services;
    }
}
