using ConsoleApp.Issues;
using McMaster.Extensions.CommandLineUtils;

namespace ConsoleApp;

[Command("issue")]
[Subcommand(typeof(CreateCommand)), Subcommand(typeof(SearchCommand))]
public class IssueCommand
{
    
}