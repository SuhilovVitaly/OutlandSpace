namespace OutlandSpace.Server.Engine.Characters
{
    public class CharactersMetrics
    {
        public int LoadedFromScenario { get; private set; }
        public int LoadedFromBaseGame { get; private set; }

        public void IncreaseLoadedFromScenario(int loadedFromScenario)
        {
            LoadedFromScenario += loadedFromScenario;
        }

        public void IncreaseLoadedFromBaseGame(int loadedFromBaseGame)
        {
            LoadedFromBaseGame += loadedFromBaseGame;
        }
    }
}