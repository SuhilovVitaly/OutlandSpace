using System;
using System.Collections.Generic;
using OutlandSpace.Universe.Engine.Dialogs;

namespace OutlandSpace.Server.Engine.Dialog
{
    [Serializable]
    public class TurnInteraction: ITurnInteraction
    {
        public TurnInteraction(IDialog rootDialog, List<IDialog> dialogs)
        {
            RootDialog = rootDialog;
            Dialogs = dialogs;
        }

        public IDialog RootDialog { get; }

        public List<IDialog> Dialogs { get; }
    }
}
