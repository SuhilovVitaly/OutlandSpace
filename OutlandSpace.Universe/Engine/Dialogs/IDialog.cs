using System.Collections.Generic;

namespace OutlandSpace.Universe.Engine.Dialogs
{
    public interface IDialog
    {
        public string Id { get; }

        public int Turn { get; }

        public string Action { get; }

        public string Text { get; }

        public List<DialogExit> Exits { get; }
    }
}
