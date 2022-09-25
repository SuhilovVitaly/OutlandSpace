﻿using System.Collections.Generic;
using System.Collections.Immutable;
using OutlandSpace.Server.Engine.Execution.Calculation;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Server.Engine.Execution
{
    public class TurnCalculate
    {
        public static ITurnInteraction GetCurrentTurnDialogs(int turn, IDialogsStorage storage)
        {
            return DialogsCalculation.Execute(storage, turn);
        }

        public static List<ICelestialObject> RecalculateLocations(int turn, ImmutableList<ICelestialObject> objects, double ticks = 1)
        {
            return RecalculateCelestialObjectsLocations.Execute(objects, turn, ticks);
        }
    }
}
