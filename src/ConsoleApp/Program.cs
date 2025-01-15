using ConsoleApp;
using MbUtils.Extensions.CommandLineUtils;

var appDataFolder = GetAppDataFolder();
if (!Directory.Exists(appDataFolder)) Directory.CreateDirectory(appDataFolder);

var wrapper = new CommandLineApplicationWrapper<JiraCliApplication>(args);

return await wrapper.ExecuteAsync();

static string GetAppDataFolder()
{
    var homeFolder = Environment.GetEnvironmentVariable("HOME")
                     ?? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    return Path.Combine(homeFolder, ".jira-cli");
}