﻿using System.Collections.Generic;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Universe.Engine.Session
{
    public interface IGameSession
    {
        int Id { get; set; }
        int Turn { get; }
        bool IsPause { get; }
        bool IsDebug { get; set; }
        string ScenarioName { get; }
        List<ICelestialObject> CelestialObjects { get; }

        void UpdateTurn(List<ICelestialObject> objects, int turns);
    }
}