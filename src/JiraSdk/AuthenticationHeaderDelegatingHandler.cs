using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Options;

namespace JiraSdk;

public class AuthenticationHeaderDelegatingHandler(IOptions<JiraSdkConfiguration> config) : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var base64EncodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{config.Value.Username}:{config.Value.ApiToken}"));
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedCredentials);
        return base.SendAsync(request, cancellationToken);
    }
}