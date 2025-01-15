using McMaster.Extensions.CommandLineUtils;

namespace ConsoleApp;

[Command("jira")]
[Subcommand(typeof(IssueCommand))]
public class JiraCliApplication
{
    
}