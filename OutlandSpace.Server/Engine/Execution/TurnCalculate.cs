using System.Collections.Generic;
using OutlandSpace.Server.Engine.Execution.Calculation;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Server.Engine.Execution
{
    public class TurnCalculate
    {
        public static ITurnDialogs GetCurrentTurnDialogs(int turn, IDialogsStorage storage)
        {
            return DialogsCalculation.Execute(storage, turn);
        }

        public static List<ICelestialObject> RecalculateLocations(int turn, List<ICelestialObject> objects, double ticks = 1)
        {
            return RecalculateCelestialObjectsLocations.Execute(objects, turn, ticks);
        }
    }
}
