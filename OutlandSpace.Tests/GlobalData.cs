using System;
using OutlandSpace.Server;
using OutlandSpace.Server.Engine.Dialog;

namespace OutlandSpace.Tests
{
    public static class GlobalData
    {
        public static int DialogsCountInTests { get; set; } = 7;

        public static int DialogsCount { get; set; } = 1;

        public static string MainScenarioId { get; } = "7045d54c-412b-429e-b1ed-43e62dcc10e6";

        private static Lazy<LocalServer> _localServer = new Lazy<LocalServer>(() => new LocalServer("TestsData"));

        private static DialogsStorage storage = new DialogFactory().Initialize("TestsData");

        public static LocalServer LocalServerWithTestData
        {
            get
            {
                return _localServer.Value;
            }
        }

        public static DialogsStorage DialogsStorageWithTestData
        {
            get
            {
                return storage;
            }
        }
    }
}
