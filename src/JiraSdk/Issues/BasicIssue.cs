namespace JiraSdk.Issues;

public record BasicIssue(BasicIssueFields Fields);

public record BasicIssueFields(
    IssueDescription Description, 
    IssueTypeIdentifier Issuetype, 
    string[] Labels, 
    ProjectIdentifier Project, 
    string Summary);

public record IssueDescription(List<ParagraphContent> Content, string Type, int Version);

public abstract record Content(string Type);

public record ParagraphContent(List<TextContent> Content) : Content("paragraph");

public record TextContent(string Text) : Content("text");

public record IssueTypeIdentifier(string Name);

public record ProjectIdentifier(string Key);