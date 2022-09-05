using System;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Universe.Engine.Dialogs;

namespace OutlandSpace.Server.Engine
{
    public class Api
    {
        public IDialog GetDialog(string id, DialogsStorage dialogStorage)
        {
            return dialogStorage.Dialogs.Find((IDialog obj) => obj.Id == id);
        }
    }
}
