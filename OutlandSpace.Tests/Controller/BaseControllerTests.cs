using System.Threading;
using NUnit.Framework;
using OutlandSpace.Controller;

namespace OutlandSpace.Tests
{
    public class BaseControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WorkerStatusIsRunningShouldBeCorrectForNewWorkerInstance()
        {
            var worker = new Worker();

            Assert.False(worker.WorkerStatus.IsRunning);
        }

        [Test]
        public void WorkerDefaultSnapshotShouldBeCorrectAfterGameServerInitialization()
        {
            var worker = new Worker();

            worker.StartNewGameSession("7045d54c-412b-429e-b1ed-43e62dcc10e6", 0);

            Thread.Sleep(1000);

            var snapshot = worker.GetSnapshot();

            Assert.AreEqual(2, snapshot.GetCelestialObjects().Count);
            Assert.AreEqual(1, snapshot.Dialogs.Dialogs.Count);
            Assert.AreEqual("x90adc8a-eca5-4c84-b4a1-682098bb4829", snapshot.Dialogs.RootDialog.Id);

            Assert.False(worker.WorkerStatus.IsRunning);
        }
    }
}
