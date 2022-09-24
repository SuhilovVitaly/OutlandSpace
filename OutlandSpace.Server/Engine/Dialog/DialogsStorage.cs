using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;
using OutlandSpace.Universe.Engine.Dialogs;

namespace OutlandSpace.Server.Engine.Dialog
{
    [Serializable]
    public class DialogsStorage: IDialogsStorage
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        public List<IDialog> Dialogs { get; }  

        public DialogsStorage(List<IDialog> dialogs)
        {
            Dialogs = dialogs;
        }

        public IDialog GetDialog(string guid)
        {
            return Dialogs.FirstOrDefault(dialog => dialog.Id == guid);
        }

        public List<IDialog> GetDialogChain(string rootDialogId)
        {
            var returnCollection = new List<IDialog>();

            var rootDialog = GetDialog(rootDialogId);

            if (rootDialog is null) return new List<IDialog>();

            returnCollection = GetExitsDialogs(rootDialogId, returnCollection);

            return returnCollection;
        }

        public List<IDialog> GetExitsDialogs(string rootDialogId, List<IDialog> dialogs, bool isRecursion = true)
        {
            var rootDialog = GetDialog(rootDialogId);
            if (rootDialog is null) return dialogs;

            foreach (var exit in rootDialog.Exits)
            {
                var dialog = GetDialog(exit.NextDialogId);

                if (dialog is null)
                {
                    Logger.Error($"Exit '{exit}' from dialog '{rootDialogId}' not found.");
                }
                else
                {
                    dialogs.Add(dialog);
                    if(isRecursion) GetExitsDialogs(dialog.Id, dialogs);
                }
            }

            return dialogs;
        }
    }
}
