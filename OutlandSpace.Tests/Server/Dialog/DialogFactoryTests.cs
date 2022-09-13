using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Universe.Engine.Dialogs;

namespace OutlandSpace.Tests.Server.Dialog
{
    [TestFixture]
    public class DialogFactoryTests
    {
        private string dialogId = "a90adc8a-eca5-4c84-b4a1-682098bb4829";
        private string nextDialogIdForFirstExit = "0d35df2c-2018-4a90-8fd7-af3cc0b1f914"; 
        private string nextDialogIdForSecondExit = "d37a25a8-757d-48a3-8fdc-1951cb0b9589"; 
        private string exitIdForFirstExit = "2c052641-3a37-451e-a593-198be707efa7";
        private string exitIdForSecondExit = "f022f9f0-ac27-475e-9f1d-fcd3d5b647da"; 

        [Test]
        public void ParsedFromStringDialogShouldBeCorrect()
        {
            var dialogFactory = new DialogFactory();
            var jsonString = "{\"Id\":\"a90adc8a-eca5-4c84-b4a1-682098bb4829\",\"Turn\":1,\"Action\":\"window_dialog_common\",\"Exits\":[{\"Id\":\"2c052641-3a37-451e-a593-198be707efa7\",\"Label\":\"Label 1\",\"NextDialogId\":\"0d35df2c-2018-4a90-8fd7-af3cc0b1f914\"},{\"Id\":\"f022f9f0-ac27-475e-9f1d-fcd3d5b647da\",\"Label\":\"Label 2\",\"NextDialogId\":\"d37a25a8-757d-48a3-8fdc-1951cb0b9589\"}]}";
            var dialog = dialogFactory.ParseDialog(jsonString);

            Assert.AreEqual(dialog.Id.ToString(), dialogId);
            Assert.AreEqual(dialog.Turn, 1);
            Assert.AreEqual(dialog.Action, "window_dialog_common");
            Assert.AreEqual(dialog.Exits.Count, 2);
            Assert.AreEqual(dialog.Exits[0].Label, "Label 1");
            Assert.AreEqual(dialog.Exits[1].Label, "Label 2");
            Assert.AreEqual(dialog.Exits[0].Id, exitIdForFirstExit);
            Assert.AreEqual(dialog.Exits[1].Id, exitIdForSecondExit);
            Assert.AreEqual(dialog.Exits[0].NextDialogId, nextDialogIdForFirstExit);
            Assert.AreEqual(dialog.Exits[1].NextDialogId, nextDialogIdForSecondExit);
        }

        [Test]
        public void DialogFactoryInitializeTest()
        {
            var dialogFactory = new DialogFactory();

            var storage = dialogFactory.Initialize("TestsData");

            Assert.AreEqual(storage.Dialogs.Count, 5);
            Assert.AreEqual(storage.Dialogs[0].Turn, 1);
        }

        [Test]
        public void DialogAfterSerializationShouldBeCorrect()
        {
            var guid = Guid.NewGuid();
            
            var exits = new List<DialogExit>
            {
                new DialogExit(exitIdForFirstExit, "Label 1", nextDialogIdForFirstExit),
                new DialogExit(exitIdForSecondExit, "Label 2", nextDialogIdForSecondExit)
            };
            var dialogManual = new CommonDialog(guid.ToString(), 1, string.Empty, exits);
            var jsonDialogManual = JsonConvert.SerializeObject(dialogManual);

            var exceptedJsonString = "{\"Id\":\"" + guid.ToString() + "\",\"Turn\":1,\"Action\":\"\",\"Exits\":[{\"Id\":\"2c052641-3a37-451e-a593-198be707efa7\",\"Label\":\"Label 1\",\"NextDialogId\":\"0d35df2c-2018-4a90-8fd7-af3cc0b1f914\",\"Action\":\"\"},{\"Id\":\"f022f9f0-ac27-475e-9f1d-fcd3d5b647da\",\"Label\":\"Label 2\",\"NextDialogId\":\"d37a25a8-757d-48a3-8fdc-1951cb0b9589\",\"Action\":\"\"}]}";

            Assert.AreEqual(jsonDialogManual, exceptedJsonString);
        }

        [Test]
        public void DialogsAfterSerializationShouldBeCorrect()
        {
            var guid = Guid.NewGuid();

            var exits = new List<DialogExit>
            {
                new DialogExit(exitIdForFirstExit, "Label 1", nextDialogIdForFirstExit),
                new DialogExit(exitIdForSecondExit, "Label 2", nextDialogIdForSecondExit)
            };
            var dialogManual = new CommonDialog(guid.ToString(), 1, string.Empty, exits);

            var guidExit = Guid.NewGuid();
            var exitsExit = new List<DialogExit>
            {
                new DialogExit(exitIdForFirstExit, "Label 1", nextDialogIdForFirstExit)
            };

            var dialogExit = new CommonDialog(guidExit.ToString(), 1, string.Empty, exitsExit);

            var dialogCollection = new List<IDialog>{dialogManual, dialogExit };

            var jsonDialogsCollection = JsonConvert.SerializeObject(dialogCollection);

            var jsonDialogManual = JsonConvert.SerializeObject(dialogManual);

            var exceptedJsonString = "{\"Id\":\"" + guid.ToString() + "\",\"Turn\":1,\"Action\":\"\",\"Exits\":[{\"Id\":\"2c052641-3a37-451e-a593-198be707efa7\",\"Label\":\"Label 1\",\"NextDialogId\":\"0d35df2c-2018-4a90-8fd7-af3cc0b1f914\",\"Action\":\"\"},{\"Id\":\"f022f9f0-ac27-475e-9f1d-fcd3d5b647da\",\"Label\":\"Label 2\",\"NextDialogId\":\"d37a25a8-757d-48a3-8fdc-1951cb0b9589\",\"Action\":\"\"}]}";

            Assert.AreEqual(jsonDialogManual, exceptedJsonString);
        }

        [Test]
        public void GetDialogByGuidShouldBeCorrectTest()
        {
            var dialogFactory = new DialogFactory();

            var storage = dialogFactory.Initialize("TestsData");

            var dialog = storage.GetDialog(dialogId);

            Assert.AreEqual(dialog.Id.ToString(), dialogId);
            Assert.AreEqual(dialog.Turn, 1);
            Assert.AreEqual(dialog.Action, "window_dialog_common");
            Assert.AreEqual(dialog.Exits.Count, 2);
            Assert.AreEqual(dialog.Exits[0].Label, "Label 1");
            Assert.AreEqual(dialog.Exits[1].Label, "Label 2");
            Assert.AreEqual(dialog.Exits[0].Id, exitIdForFirstExit);
            Assert.AreEqual(dialog.Exits[1].Id, exitIdForSecondExit);
            Assert.AreEqual(dialog.Exits[0].NextDialogId, nextDialogIdForFirstExit);
            Assert.AreEqual(dialog.Exits[1].NextDialogId, nextDialogIdForSecondExit);
        }


    }    
}
