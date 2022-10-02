using System;
using System.Collections.Generic;

namespace OutlandSpace.Universe.Engine.Dialogs
{
    [Serializable]
    public class CommonDialog: IDialog
    {
        public string Id { get; }
        public int Turn { get; }

        public string Action { get; }
        public string Text { get; }

        public List<DialogExit> Exits { get; }

        public CommonDialog(string id, int turn, string action, List<DialogExit> exits, string text = "")
        {
            Id = id;
            Turn = turn;
            Text = text;
            Action = action;
            Exits = exits;
        }
    }
}
