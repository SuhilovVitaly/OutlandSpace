using NUnit.Framework;

namespace OutlandSpace.Tests.Universe.Tools
{
    [TestFixture]
    public class FilesFactoryTests
    {
        [Test]
        public void FilesFactoryBaseTest()
        {
            var files = OutlandSpace.Universe.Tools.FilesFactory.GetFilesContentFromDirectory("TestsData");

            Assert.AreEqual(2, files.Count);
        }

        [Test]
        public void FilesFactorySubfoldersTest()
        {
            var files = OutlandSpace.Universe.Tools.FilesFactory.GetFilesContentFromDirectory("TestsData/Dialogs");

            Assert.AreEqual(1, files.Count);
        }
    }
}
