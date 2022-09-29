using System.Threading;
using NUnit.Framework;
using OutlandSpace.Controller;
using OutlandSpace.Universe.Engine.Session.Commands;

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

            Assert.False(worker.IsRunning());
        }

        [Test]
        public void WorkerDefaultSnapshotShouldBeCorrectAfterGameServerInitialization()
        {
            var worker = new Worker();

            worker.StartNewGameSession(GlobalData.MainScenarioId, 0);


            Thread.Sleep(1500);

            var snapshot = worker.GetSnapshot();

            Assert.AreEqual(2, snapshot.GetCelestialObjects().Count);
            Assert.AreEqual(1, snapshot.Interaction.Dialogs.Count);
            Assert.AreEqual("x90adc8a-eca5-4c84-b4a1-682098bb4829", snapshot.Interaction.RootDialog.Id);

            Assert.False(worker.IsRunning());
        }

        [Test]
        public void WorkerShouldBeStartedAfterGameServerInitialization()
        {
            var worker = new Worker();

            worker.StartNewGameSession(GlobalData.MainScenarioId, 100);

            Thread.Sleep(1000);

            var snapshot = worker.GetSnapshot();

            Assert.AreEqual(2, snapshot.GetCelestialObjects().Count);
            Assert.AreEqual(1, snapshot.Interaction.Dialogs.Count);
            Assert.AreEqual("x90adc8a-eca5-4c84-b4a1-682098bb4829", snapshot.Interaction.RootDialog.Id);

            Assert.False(worker.IsRunning());

            Thread.Sleep(1000);

            var currentRequestsCount = worker.Metrics.TickCounter;

            Assert.IsTrue(currentRequestsCount > 0);

            Thread.Sleep(1000);

            Assert.IsTrue(worker.Metrics.TickCounter > currentRequestsCount);            
        }

        [Test]
        public void WorkerShouldRefreshSnapshotForRunningServer()
        {
            var worker = new Worker();

            worker.StartNewGameSession(GlobalData.MainScenarioId, 100);

            worker.SessionResume();

            Thread.Sleep(3500);

            var snapshot = worker.GetSnapshot();

            Assert.IsTrue(snapshot.Turn > 3);
            Assert.IsTrue(snapshot.GetCelestialObjects().Count == 2);
        }

        [Test]
        public void WorkerShouldRefreshSnapshotForRunningServerAfterPause()
        {
            var worker = new Worker();

            worker.StartNewGameSession(GlobalData.MainScenarioId, 100);

            worker.SessionResume();

            Thread.Sleep(3500);

            var snapshot = worker.GetSnapshot();

            Assert.IsTrue(snapshot.Turn > 3);
            Assert.IsTrue(snapshot.GetCelestialObjects().Count == 2);

            worker.SessionPause();

            Thread.Sleep(1500);

            var snapshotAfterPause = worker.GetSnapshot();

            Assert.IsTrue(snapshot.Turn == snapshotAfterPause.Turn);

            worker.SessionResume();

            Thread.Sleep(1500);

            var snapshotAfterResume = worker.GetSnapshot();

            Assert.IsTrue(snapshot.Turn < snapshotAfterResume.Turn);
        }

        [Test]
        public void WorkerShouldPushCommandToServerCorrect()
        {
            var worker = new Worker();

            worker.StartNewGameSession(GlobalData.MainScenarioId, 100);

            ICommand iCommand = new CommandDialogAnswer("Dialog 1", "Exit 1");

            worker.PushCommand(iCommand);

            Assert.AreEqual(1, worker.Metrics.Commands);
        }

        [Test]
        public void ManualTurnExecuteOnServerShouldBeCorrect()
        {
            var worker = new Worker();

            worker.StartNewGameSession(GlobalData.MainScenarioId, 100);

            ICommand iCommand = new CommandDialogAnswer("Dialog 1", "Exit 1");

            worker.PushCommand(iCommand);

            Assert.AreEqual(1, worker.Metrics.Commands);

            worker.ExecuteCommand();
        }

    }
}
