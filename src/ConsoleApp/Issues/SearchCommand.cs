using JiraSdk.Issues;
using JiraSdk.Search;
using McMaster.Extensions.CommandLineUtils;

namespace ConsoleApp.Issues;

[Command("search")]
public class SearchCommand(IConsole console, ISearchApi searchApi)
{
    [Argument(0, Name = "JQL")]
    private string Jql { get; } = string.Empty;
    
    private async Task OnExecuteAsync()
    {
        console.WriteLine("Searching for issues...");
        
        var request = new SearchForIdsRequest
        {
            Jql = Jql
        };
        
        var response = await searchApi.SearchForIdsAsync(request);

        var joined = string.Join(",", response.IssueIds);
        
        console.WriteLine("Issue IDs: {0}", joined);
    }
}