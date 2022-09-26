using OutlandSpace.Universe.Engine.Dialogs;

namespace OutlandSpace.Server.Engine
{
    public class Api
    {
        public IDialog GetDialog(string id, IDialogsStorage dialogStorage)
        {
            return dialogStorage.Dialogs.Find((IDialog obj) => obj.Id == id);
        }
    }
}
