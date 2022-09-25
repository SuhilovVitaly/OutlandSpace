using OutlandSpace.Server.Engine.Characters;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Universe.Engine.Dialogs;

namespace OutlandSpace.Server.Engine.Session
{
    public class ResourcesStorage: IResourcesStorage
    {
        public IDialogsStorage Dialogs { get; }
        public ICharactersStorage Characters { get; }

        public ResourcesStorage(Resources resources)
        {
            Dialogs = new DialogsStorage(resources.Dialogs);
            Characters = new CharactersStorage(resources.Characters, null);
        }
    }
}