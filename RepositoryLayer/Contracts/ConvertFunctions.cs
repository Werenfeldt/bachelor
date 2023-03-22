namespace RepositoryLayer;

public static class ConvertFunctions
{

    public static GitFolderDTO GitFolderMapToDTO(GitFolder gitFolder)
    {
        var scriptList = new List<ScriptFileDTO>();

        foreach (var script in gitFolder.ScriptFiles)
        {
            scriptList.Add(ScriptFileMapToDTO(script));
        }

        return new GitFolderDTO(gitFolder.Id, gitFolder.OwnerName, gitFolder.Name, scriptList);
    }

    public static GitFolderDTO GitFolderMapToDTO(CreateGitFolderDTO gitFolder)
    {
        return new GitFolderDTO(gitFolder.Id, gitFolder.OwnerName, gitFolder.Name, gitFolder.scriptFileDTOs);
    }

    public static GitFolder GitFolderMapToEntity(CreateGitFolderDTO gitFolder)
    {
        var scriptList = new List<ScriptFile>();

        foreach (var script in gitFolder.scriptFileDTOs)
        {
            scriptList.Add(ScriptFileMapToEntity(script));
        }

        return new GitFolder(gitFolder.Name, gitFolder.OwnerName) { ScriptFiles = scriptList };

    }

    private static ScriptFile ScriptFileMapToEntity(ScriptFileDTO scriptFile)
    {
        return new ScriptFile(scriptFile.GitUrl, scriptFile.HtmlUrl, scriptFile.Url, scriptFile.Path, scriptFile.Name, scriptFile.Sha, scriptFile.Content);
    }

    private static ScriptFileDTO ScriptFileMapToDTO(ScriptFile scriptFile)
    {
        return new ScriptFileDTO(scriptFile.Id, scriptFile.DateCreated, scriptFile.Name, scriptFile.GitUrl, scriptFile.HtmlUrl, scriptFile.ApiUrl, scriptFile.FilePath, scriptFile.Sha, scriptFile.RawContent);
    }


}