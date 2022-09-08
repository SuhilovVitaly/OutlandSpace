using System.Collections.Generic;
using NUnit.Framework;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Universe.Engine.Dialogs;

namespace OutlandSpace.Tests.Server.Dialog
{
    [TestFixture]
    public class DialogsStorageTests
    {
        private DialogsStorage storage;

        [SetUp]
        public void Init()
        {
            storage = new DialogFactory().Initialize("TestsData");
        }

        [Test]
        public void GetDialogChainShouldBeCorrect()
        {
            var dialogsChain = storage.GetDialogChain("a90adc8a-eca5-4c84-b4a1-682098bb4829");

            Assert.That(dialogsChain.Count == 3);
        }

        [Test]
        public void GetDialogChainShouldReturnEmptyCollectionForNotExistRootDialog()
        {
            var dialogsChain = storage.GetDialogChain("Not exist");

            Assert.That(dialogsChain.Count == 0);
        }

        [Test]
        public void GetDialogExitsShouldReturnCorrectDialogsCollection()
        {
            var dialogsCollection = storage.GetExitsDialogs("a90adc8a-eca5-4c84-b4a1-682098bb4829", new List<IDialog>(), false);

            Assert.That(dialogsCollection.Count == 2);
        }


    }
}
