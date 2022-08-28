using System;
namespace OutlandSpace.Universe.Engine.Dialogs
{
    [Serializable]
    public class CommonDialog: IDialog
    {
        public Guid Id { get; }

        public CommonDialog(Guid id)
        {
            Id = id;
        }
    }
}
