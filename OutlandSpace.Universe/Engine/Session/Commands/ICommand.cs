using System;
namespace OutlandSpace.Universe.Engine.Session.Commands
{
    public interface ICommand
    {
        CommandTypes Type { get; set; }
    }
}
