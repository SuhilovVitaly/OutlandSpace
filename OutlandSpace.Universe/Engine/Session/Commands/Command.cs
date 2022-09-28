using System;
namespace OutlandSpace.Universe.Engine.Session.Commands
{
    [Serializable]
    public class Command: ICommand
    {
        public CommandTypes Type { get; set; }
    }
}
