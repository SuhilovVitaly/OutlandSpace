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

        public List<DialogExit> Exits { get; }

        public CommonDialog(string id, int turn, string action, List<DialogExit> exits)
        {
            Id = id;
            Turn = turn;
            Action = action;
            Exits = exits;
        }
    }
}
