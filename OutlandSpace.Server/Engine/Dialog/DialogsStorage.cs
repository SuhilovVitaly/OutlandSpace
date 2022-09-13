using System;
using System.Collections.Generic;
using System.Reflection;
using log4net;
using OutlandSpace.Universe.Engine.Dialogs;

namespace OutlandSpace.Server.Engine.Dialog
{
    [Serializable]
    public class DialogsStorage
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public List<IDialog> Dialogs { get; }  

        public DialogsStorage(List<IDialog> dialogs)
        {
            Dialogs = dialogs;
        }

        public IDialog GetDialog(string guid)
        {
            foreach (var dialog in Dialogs)
            {
                if (dialog.Id.ToString() == guid) return dialog;
            }

            return null;
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
                    _logger.Error($"Exit '{exit}' from dialog '{rootDialogId}' not found.");
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
