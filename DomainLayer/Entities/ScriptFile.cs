namespace DomainLayer;
public class ScriptFile
{
    public Guid Id { get; set; }

    public Guid OwnerId { get; set; }

    public DateTime DateCreated { get; set; }

    public string Translation { get; set; }

    public string GitUrl { get; set; }
    public string HtmlUrl { get; set; }
    public string ApiUrl { get; set; }
    public string FilePath { get; set; }
    public string Name { get; set; }
    public string Sha { get; set; }
    public string RawContent { get; set; }

    public ScriptFile(string gitUrl, string htmlUrl, string apiUrl, string filePath, string name, string sha, string rawContent)
    {
        GitUrl = gitUrl;
        HtmlUrl = htmlUrl;
        ApiUrl = apiUrl;
        FilePath = filePath;
        Name = name;
        Sha = sha;
        RawContent = rawContent;
    }

    public override string ToString()
    {
        return "File Name: " + Name + "\n"
                + "File Path: " + FilePath + "\n"
                + "Raw Content:" + "\n"
                + "============================" + "\n"
                + RawContent + "\n"
                + "============================" + "\n";
    }

}