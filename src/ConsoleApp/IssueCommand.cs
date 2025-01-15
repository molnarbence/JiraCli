using ConsoleApp.Issues;
using McMaster.Extensions.CommandLineUtils;

namespace ConsoleApp;

[Command("issue")]
[Subcommand(typeof(CreateCommand))]
public class IssueCommand
{
    
}