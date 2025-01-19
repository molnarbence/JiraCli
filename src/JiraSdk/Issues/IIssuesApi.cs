using Refit;

namespace JiraSdk.Issues;

public interface IIssuesApi
{
    [Post("/")]
    Task<CreateIssueResponse> CreateBasicIssueAsync([Body] BasicIssue issue);
}