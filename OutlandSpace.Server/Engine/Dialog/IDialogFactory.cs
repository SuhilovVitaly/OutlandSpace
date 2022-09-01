using System;
using OutlandSpace.Universe.Engine.Dialogs;

namespace OutlandSpace.Server.Engine.Dialog
{
    public interface IDialogFactory
    {
        IDialog ParseDialog(string body);
    }
}
