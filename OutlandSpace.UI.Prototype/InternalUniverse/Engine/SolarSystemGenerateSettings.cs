namespace OutlandSpace.UI.Prototype.InternalUniverse.Engine
{
    public class SolarSystemGenerateSettings
    {
        public readonly (int min, int max) Stations = (3, 12);

        public readonly (int min, int max) Asteroids = (30, 120);

        public readonly (double min, double max) AsteroidsSpeed = (1, 20);

        public readonly (double width, double height) Size = (500, 500);
    }
}