using NUnit.Framework;
using OutlandSpace.Server.Engine.Equipment;

namespace OutlandSpace.Tests.Server.Equipment
{
    [TestFixture]
    public class ComplexEquipmentFactoryTests
    {
        [Test]
        public void LoadingEquipmentShouldBeCorrect()
        {
            var equipmentStorage = new ModuleFactory().Initialize("TestsData");

            Assert.AreEqual(equipmentStorage.Modules.Count, 2);
        }
    }
}