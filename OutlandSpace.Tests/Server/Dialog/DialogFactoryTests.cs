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
            var dialog = new DialogFactory().GetDialog("{\"Id\":1000}");

            Assert.AreEqual(dialog.Id, 1000);

        }
    }
}
