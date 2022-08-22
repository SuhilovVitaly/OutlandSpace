using System;
using System.Collections.Generic;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Server.Engine.Session
{
    [Serializable]
    public class GameSession: IGameSession
    {
        private protected StatusController Status = new StatusController();

        public GameSession()
        {
            Status.Pause();
        }

        public GameSession(List<ICelestialObject> objects): this()
        {
            CelestialObjects = objects;
        }

        public int Id { get; set; }

        public int Turn { get;}


        public List<ICelestialObject> GetCelestialObjects()
        {
            throw new NotImplementedException();
        }

        #region IStatus implementation

        public void Resume() => Status.Resume();
        public void Pause() => Status.Pause();
        public bool IsPause => Status.IsPause;

        public bool IsDebug { get; set; } = false;

        public string ScenarioName => throw new NotImplementedException();

        public List<ICelestialObject> CelestialObjects { get; }

        #endregion

    }
}
