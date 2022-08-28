using OutlandSpace.Server.Engine.Dialog;

namespace OutlandSpace.Server.Engine
{
    public class Health
    {
        public int DialogsCount(DialogsStorage dialogStorage)
        {
            return dialogStorage.Dialogs.Count;
        }
    }
}
