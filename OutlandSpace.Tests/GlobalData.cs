using System;
using OutlandSpace.Server;

namespace OutlandSpace.Tests
{
    public static class GlobalData
    {
        public static int DialogsCountInTests { get; set; } = 5;

        public static int DialogsCount { get; set; } = 1;

        private static Lazy<LocalServer> _localServer = new Lazy<LocalServer>(() => new LocalServer("TestsData"));

        public static LocalServer LocalServerWithTestData
        {
            get
            {
                return _localServer.Value;
            }
        }
    }
}
