using System;
using System.IO;
using NUnit.Framework;

namespace OutlandSpace.Tests
{
    [TestFixture]
    public class GeneralTests
    {
        [Test]
        public void DirectoryTest()
        {
            // This will get the current WORKING directory(i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result

            // This will get the current PROJECT bin directory (ie ../bin/)
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;


            string solutionDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;

            // This will get the current PROJECT directory
            var projectDirectoryName = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        }
    }
}
