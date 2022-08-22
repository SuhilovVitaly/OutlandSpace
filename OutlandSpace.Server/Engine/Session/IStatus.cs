
namespace OutlandSpace.Server.Engine.Session
{
    interface IStatus
    {
        bool IsPause { get; }

        void Resume();

        void Pause();
    }
    
}
