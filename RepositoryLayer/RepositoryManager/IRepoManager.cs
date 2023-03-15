namespace RepositoryLayer;

public interface IRepoManager
{
    IScriptFileRepository ScriptFileRepository { get; }

    IGitFolderRepository GitFolderRepository { get; }

}
