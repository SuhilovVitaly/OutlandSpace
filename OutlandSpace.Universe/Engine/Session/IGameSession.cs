using System;
using System.Collections.Generic;
using OutlandSpace.Universe.Engine.Dialogs;
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
        IGameTurnSnapshot ToGameTurnSnapshot();
        IGameTurnSnapshot TurnExecute();
        IGameTurnSnapshot RealTimeTurnExecute();
        ITurnInteraction Interaction { get; }
        IDialogsStorage Storage { get; }
        IExecuteMetrics Metrics { get; }
    }
}
