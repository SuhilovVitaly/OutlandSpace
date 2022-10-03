using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using OutlandSpace.Universe.Entities.Characters;
using OutlandSpace.Universe.Entities.Equipment;
using OutlandSpace.Universe.Entities.Equipment.Reactor;

namespace OutlandSpace.Tests.Universe.Tools
{
    [TestFixture]
    public class ResourceLoaderTests
    {
        [Test]
        public void LoadCharactersFromGeneralStorageShouldBuCorrect()
        {
            var rootPath = Path.Combine(Environment.CurrentDirectory, @"TestsData\Characters");

            var objects = OutlandSpace.Universe.Tools.ResourceLoader<CrewMember>.LoadFromFolder(rootPath);

            Assert.AreEqual(2, objects.Count);
        }

        [Test]
        public void LoadReactorModulesFromGeneralStorageShouldBuCorrect()
        {
            var rootPath = Path.Combine(Environment.CurrentDirectory, @"TestsData\Modules\Reactor");

            var reactors = OutlandSpace.Universe.Tools.ResourceLoader<Reactor>.LoadFromFolder(rootPath);

            Assert.AreEqual(2, reactors.Count);

            var modules = new List<IModule>();

            modules.AddRange(reactors);

            Assert.AreEqual(2, modules.Count);
        }
    }
}