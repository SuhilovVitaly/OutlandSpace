using System.Collections.Generic;
using OutlandSpace.UI.Prototype.InternalUniverse.Entities.CelestialObjects;
using OutlandSpace.Universe.Entities.CelestialObjects;
using OutlandSpace.Universe.Tools;

namespace OutlandSpace.UI.Prototype.InternalUniverse.Engine
{
    public class BasicStarSystemFactory: IStarSystemFactory
    {
        private readonly SolarSystemGenerateSettings settings = new SolarSystemGenerateSettings();

        private readonly List<Station> _stations = new List<Station>();
        private GenerationTool random;

        public IStarSystem Generate(int generationKey)
        {
            random = new GenerationTool(generationKey);

            var starSystem = GenerateEmptyStarSystem();

            var stations = GenerateStations(random, settings);

            var asteroids = GenerateAsteroids(random, settings);

            starSystem.SetCelestialObjects(stations);

            return starSystem;
        }

        public IStarSystem GenerateEmptyStarSystem()
        {
            var emptyStarSystem = new StarSystem
            {
                Name = random.GenerateCelestialObjectName()
            };

            return emptyStarSystem;
        }

        public List<ICelestialObject> GenerateStations(GenerationTool randomTool, SolarSystemGenerateSettings fSettings)
        {
            var stationsCount = random.GetInteger(fSettings.Asteroids.min, fSettings.Asteroids.max);

            var stations = new List<ICelestialObject>();

            for (var stationIndex = 0; stationIndex < stationsCount; stationIndex++)
            {
                stations.Add(new Station{Name = randomTool .GenerateCelestialObjectName()});
            }

            return stations;
        }

        public List<ICelestialObject> GenerateAsteroids(GenerationTool randomTool, SolarSystemGenerateSettings fSettings)
        {
            var stationsCount = random.GetInteger(fSettings.Asteroids.min, fSettings.Asteroids.max);

            var stations = new List<ICelestialObject>();

            for (var stationIndex = 0; stationIndex < stationsCount; stationIndex++)
            {
                //string id, double direction, double velocity, Point location,

                var id = randomTool.GetId().ToString();
                var direction = randomTool.Direction();
                var velocity = randomTool.GetDouble(fSettings.AsteroidsSpeed.min, fSettings.AsteroidsSpeed.max);

                //stations.Add(new Asteroid{ Name = randomTool.GenerateCelestialObjectName() });
            }

            return stations;
        }

        public List<Station> GetStations()
        {
            return _stations;
        }
    }
}