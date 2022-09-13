using System;
using System.Collections.Generic;
using OutlandSpace.Universe.Engine.Dialogs;

namespace OutlandSpace.Server.Engine.Dialog
{
    [Serializable]
    public class TurnDialogs: ITurnDialogs
    {
        public TurnDialogs(IDialog rootDialog, List<IDialog> dialogs)
        {
            RootDialog = rootDialog;
            Dialogs = dialogs;
        }

        public IDialog RootDialog { get; }

        public List<IDialog> Dialogs { get; }
    }
}
