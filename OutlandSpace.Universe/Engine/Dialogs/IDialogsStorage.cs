using System;
using System.Collections.Generic;

namespace OutlandSpace.Universe.Engine.Dialogs
{
    public interface IDialogsStorage
    {
        List<IDialog> Dialogs { get; }
        IDialog GetDialog(string guid);
        List<IDialog> GetDialogChain(string rootDialogId);
        List<IDialog> GetExitsDialogs(string rootDialogId, List<IDialog> dialogs, bool isRecursion = true);
    }
}
