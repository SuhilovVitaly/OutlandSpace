using System;
using OutlandSpace.Server;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Server.Engine.Session;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.Tests
{
    public static class GlobalData
    {
        public static int DialogsCountInTests { get; set; } = 5;

        public static int DialogsCount { get; set; } = 1;

        public static string MainScenarioId { get; } = "7045d54c-412b-429e-b1ed-43e62dcc10e6";

        private static readonly Lazy<LocalServer> LocalServer = new Lazy<LocalServer>(() => new LocalServer("TestsData"));

        private static readonly DialogsStorage Storage = new DialogFactory().Initialize("TestsData");

        public static IGameSession GameSessionWithMainScenarioId
        {
            get
            {
                return new GameSession(new Scenario(MainScenarioId, DialogsStorageWithTestData));
            }
            
        }

        public static LocalServer LocalServerWithTestData
        {
            get
            {
                LocalServer.Value.Initialization(MainScenarioId);
                return LocalServer.Value;
            }
        }

        public static DialogsStorage DialogsStorageWithTestData
        {
            get
            {
                return Storage;
            }
        }
    }
}
