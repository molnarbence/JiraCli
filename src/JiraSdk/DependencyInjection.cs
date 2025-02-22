using JiraSdk.Issues;
using JiraSdk.Search;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace JiraSdk;

public static class DependencyInjection
{
    public static IServiceCollection AddJiraSdk(this IServiceCollection services, IConfiguration configuration)
    {
        var jiraConfiguration = configuration.Get<JiraSdkConfiguration>() 
                            ?? throw new ApplicationException("Configuration is missing");
        
        services.AddOptions<JiraSdkConfiguration>().Bind(configuration);
        
        services.AddTransient<AuthenticationHeaderDelegatingHandler>();
        services.AddRefitClient<IIssuesApi>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri($"{jiraConfiguration.BaseUrl}/issue"))
            .AddHttpMessageHandler<AuthenticationHeaderDelegatingHandler>();
        
        services.AddRefitClient<ISearchApi>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri($"{jiraConfiguration.BaseUrl}/search"))
            .AddHttpMessageHandler<AuthenticationHeaderDelegatingHandler>();
        return services;
    }
}