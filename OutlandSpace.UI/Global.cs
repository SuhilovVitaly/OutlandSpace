using OutlandSpace.Controller;

namespace OutlandSpace.UI
{
    public static class Global
    {
        public static GameManager Game { get; private set; }
        public static UiManager Orchestration { get; private set; }

        public static void GameInitialization()
        {
            log4net.Config.XmlConfigurator.Configure();

            Game = new GameManager(new Worker());

            Orchestration = new UiManager(Game);
        }
    }
}