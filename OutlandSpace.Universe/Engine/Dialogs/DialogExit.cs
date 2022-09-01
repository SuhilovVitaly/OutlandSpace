using System;

namespace OutlandSpace.Universe.Engine.Dialogs
{
    [Serializable]
    public class DialogExit
    {
        public string Id { get; }

        public string Label { get; }

        public string NextDialogId { get; }

        public DialogExit(string id, string label, string nextDialogId)
        {
            Id = id;
            Label = label;
            NextDialogId = nextDialogId;
        }
    }
}
