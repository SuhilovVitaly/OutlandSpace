using System;
namespace OutlandSpace.Universe.Engine.Dialogs
{
    [Serializable]
    public class CommonDialog: IDialog
    {
        public int Id { get; }

        public CommonDialog(int id)
        {
            Id = id;
        }
    }
}
