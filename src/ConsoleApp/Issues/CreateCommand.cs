using McMaster.Extensions.CommandLineUtils;

namespace ConsoleApp.Issues;

[Command("create")]
public class CreateCommand(IConsole console, IIssuesApi issuesApi)
{
    [Argument(0, Name = "project", Description = "The project key.")]
    private string Project { get; } = string.Empty;
    
    [Argument(1, Name = "title", Description = "The title of the issue.")]
    private string Title { get; } = string.Empty;
    
    [Argument(2, Name = "description", Description = "The description of the issue.")]
    private string Description { get; } = string.Empty;
    
    [Option("-l|--label", Description = "Labels of the issue")]
    private string[] Labels { get; } = [];
    
    private async Task OnExecuteAsync()
    {
        console.WriteLine("Creating issue...");

        var basicIssue = new BasicIssue(
            new BasicIssueFields(
                new IssueDescription([
                    new ParagraphContent([
                        new TextContent(Description)
                    ])
                ], "doc", 1),
                new IssueTypeIdentifier("Task"),
                Labels,
                new ProjectIdentifier(Project),
                Title
            ));
        
        var response = await issuesApi.CreateBasicIssueAsync(basicIssue);
        
        console.WriteLine($"Issue created, issue key: {response.Key}");
    }
}