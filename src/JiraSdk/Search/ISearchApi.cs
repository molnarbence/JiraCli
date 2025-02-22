using Refit;

namespace JiraSdk.Search;

public interface ISearchApi
{
    [Post("/id")]
    Task<SearchForIdsResponse> SearchForIdsAsync([Body] SearchForIdsRequest request);
}