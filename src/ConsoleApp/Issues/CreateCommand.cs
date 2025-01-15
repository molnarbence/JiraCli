using System.Text;
using McMaster.Extensions.CommandLineUtils;

namespace ConsoleApp.Issues;

[Command("create")]
public class CreateCommand(IConsole console)
{
    [Argument(0, Name = "title", Description = "The title of the issue.")]
    private string Title { get; } = string.Empty;
    
    [Argument(1, Name = "description", Description = "The description of the issue.")]
    private string Description { get; } = string.Empty;
    
    private async Task OnExecuteAsync()
    {
        console.WriteLine("Creating issue...");
        await Task.Delay(1000);
        var outputFilePath = Path.Combine("issue-1.txt");

        var sb = new StringBuilder();
        sb.AppendLine($"Title: {Title}");
        sb.AppendLine($"Description: {Description}");
        
        await File.WriteAllTextAsync(outputFilePath, sb.ToString());
        console.WriteLine("Issue created!");
    }
}