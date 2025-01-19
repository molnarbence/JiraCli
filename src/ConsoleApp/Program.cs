using ConsoleApp;
using JiraSdk;
using JiraSdk.Issues;
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

wrapper.HostBuilder.ConfigureServices((context, services) => services.AddJiraSdk(context.Configuration));

return await wrapper.ExecuteAsync();

static string GetAppDataFolder()
{
    var homeFolder = Environment.GetEnvironmentVariable("HOME")
                     ?? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    return Path.Combine(homeFolder, ".jira-cli");
}