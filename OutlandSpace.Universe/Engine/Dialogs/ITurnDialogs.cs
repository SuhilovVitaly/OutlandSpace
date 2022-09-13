using System.Collections.Generic;

namespace OutlandSpace.Universe.Engine.Dialogs
{
    public interface ITurnDialogs
    {
        public IDialog RootDialog { get; }
        public List<IDialog> Dialogs { get; }
    }
}
