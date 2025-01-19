namespace JiraSdk;

public class JiraSdkConfiguration
{
    public const string SectionName = "JiraSdk";
    public required string Username { get; set; }
    public required string ApiToken { get; set; }
    public required string BaseUrl { get; set; }
}