using Refit;

namespace ConsoleApp.Issues;

public interface IIssuesApi
{
    [Post("/")]
    Task<CreateIssueResponse> CreateBasicIssueAsync([Body] BasicIssue issue);
}