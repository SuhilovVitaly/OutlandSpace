using System;
namespace OutlandSpace.Universe.Engine.Session.Commands
{
    public enum CommandTypes
    {
        DialogAnswer = 500
    }

    public static class CommandTypesExtensions
    {
        public static int ToInt(this CommandTypes command)
        {
            return (int)command;
        }
    }
}
