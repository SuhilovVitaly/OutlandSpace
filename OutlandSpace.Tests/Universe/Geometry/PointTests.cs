using NUnit.Framework;
using OutlandSpace.Universe.Geometry;

namespace OutlandSpace.Tests.Universe.Geometry
{
    [TestFixture]
    public class PointTests
    {
        [Test]
        public void ConvertToTurnSnapshotShouldBeCorrect()
        {
            Assert.IsTrue(new Point(100.0f, 100.0f).Equals(new Point(100.0f, 100.0f)));
            Assert.IsTrue(new Point(100.0f, 100.0f) == new Point(100.0f, 100.0f));

            Assert.IsFalse(new Point(100.0f, 100.0f).Equals(new Point(100.0f, 100.01f)));
            Assert.IsFalse(new Point(100.0f, 100.0f) == new Point(100.0f, 100.01f));
        }
    }
}