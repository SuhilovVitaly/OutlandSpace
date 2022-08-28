using System;
using System.Collections.Generic;
using OutlandSpace.Universe.Engine.Dialogs;

namespace OutlandSpace.Server.Engine.Dialog
{
    [Serializable]
    public class DialogsStorage
    {
        public List<IDialog> Dialogs { get; }  

        public DialogsStorage(List<IDialog> dialogs)
        {
            Dialogs = dialogs;
        }
    }
}
