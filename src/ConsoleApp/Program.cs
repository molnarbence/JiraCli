using ConsoleApp;
using ConsoleApp.Issues;
using MbUtils.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

var appDataFolder = GetAppDataFolder();
if (!Directory.Exists(appDataFolder)) Directory.CreateDirectory(appDataFolder);

var wrapper = new CommandLineApplicationWrapper<JiraCliApplication>(args);

wrapper.HostBuilder.ConfigureAppConfiguration((_, builder) =>
{
    builder.AddJsonFile(Path.Combine(appDataFolder, "appsettings.json"), optional: true);
});

wrapper.HostBuilder.ConfigureServices((context, services) =>
{
    var configuration = context.Configuration.Get<ApplicationConfiguration>() 
                        ?? throw new ApplicationException("Configuration is missing");
    
    services.AddOptions<ApplicationConfiguration>().Bind(context.Configuration);

    // setup API
    services.AddTransient<AuthenticationHeaderDelegatingHandler>();
    services.AddRefitClient<IIssuesApi>()
        .ConfigureHttpClient(client => client.BaseAddress = new Uri($"{configuration.BaseUrl}/issue"))
        .AddHttpMessageHandler<AuthenticationHeaderDelegatingHandler>();
});

return await wrapper.ExecuteAsync();

static string GetAppDataFolder()
{
    var homeFolder = Environment.GetEnvironmentVariable("HOME")
                     ?? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    return Path.Combine(homeFolder, ".jira-cli");
}