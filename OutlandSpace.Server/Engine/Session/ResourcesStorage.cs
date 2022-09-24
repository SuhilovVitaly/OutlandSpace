using OutlandSpace.Server.Engine.Characters;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Universe.Engine.Dialogs;

namespace OutlandSpace.Server.Engine.Session
{
    public class ResourcesStorage: IResourcesStorage
    {
        public IDialogsStorage Dialogs { get; }
        public ICharactersStorage Characters { get; }

        private Resources _resources;

        public ResourcesStorage(Resources resources)
        {
            _resources = resources;

            Dialogs = new DialogsStorage(_resources.Dialogs);
            Characters = new CharactersStorage(_resources.Characters, null);
        }
    }
}