using System;
using NUnit.Framework;
using OutlandSpace.Server.Engine.Dialog;

namespace OutlandSpace.Tests.Server.Dialog
{
    [TestFixture]
    public class DialogFactoryTests
    {
        [Test]
        public void DialogFactoryTest()
        {
            var guid = Guid.NewGuid();

            var dialogFactory = new DialogFactory();
            var dialog = dialogFactory.GetDialog("{\"Id\":\"a90adc8a-eca5-4c84-b4a1-682098bb4829\"}");

            Assert.AreEqual(dialog.Id, new Guid("a90adc8a-eca5-4c84-b4a1-682098bb4829"));
        }

        [Test]
        public void DialogFactoryInitializeTest()
        {
            var dialogFactory = new DialogFactory();

            var storage = dialogFactory.Initialize();

            Assert.AreEqual(storage.Dialogs.Count, 1);
        }
    }
}
