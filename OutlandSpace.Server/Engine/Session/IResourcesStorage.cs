using OutlandSpace.Server.Engine.Characters;
using OutlandSpace.Universe.Engine.Dialogs;

namespace OutlandSpace.Server.Engine.Session
{
    public interface IResourcesStorage
    {
        IDialogsStorage Dialogs { get; }
        ICharactersStorage Characters { get; }
    }
}