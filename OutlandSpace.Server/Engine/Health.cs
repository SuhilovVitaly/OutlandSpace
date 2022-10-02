using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Universe.Engine.Dialogs;

namespace OutlandSpace.Server.Engine
{
    public class Health
    {
        public int DialogsCount(IDialogsStorage dialogStorage)
        {
            return dialogStorage.Dialogs.Count;
        }
    }
}
