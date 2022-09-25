using System.Collections.Generic;

namespace OutlandSpace.Universe.Engine.Dialogs
{
    public interface ITurnInteraction
    {
        public IDialog RootDialog { get; }
        public List<IDialog> Dialogs { get; }
    }
}
