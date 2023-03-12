namespace Presentation.Data;

using Octokit;

public class GithubRepository
{
    public string Name { get; set; }
    public string Owner { get; set; }
    public IReadOnlyList<SearchCode> ScriptFiles { get; set; }

    public GithubRepository(string name, string owner, IReadOnlyList<SearchCode> scriptFiles)
    {
        this.Name = name;
        this.Owner = owner;
        this.ScriptFiles = scriptFiles;
    }

    public void printFiles()
    {
        foreach (var item in ScriptFiles)
        {
            Console.WriteLine(item.Name);
        }
    }

}
