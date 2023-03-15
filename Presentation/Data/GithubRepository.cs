namespace Presentation.Data;

using Octokit;

public class GithubRepository
{
    public string Name { get; set; }
    public string Owner { get; set; }
    public List<ScriptFile> ScriptFiles { get; set; }

    public GithubRepository(string name, string owner, List<ScriptFile> scriptFiles)
    {
        this.Name = name;
        this.Owner = owner;
        this.ScriptFiles = scriptFiles;
    }

    public void printFiles()
    {
        foreach (var item in ScriptFiles)
        {
            Console.WriteLine(item.ToString());
        }
    }

}
