using log4net.Config;
using NUnit.Framework;

namespace OutlandSpace.Tests
{
    [SetUpFixture]
    public class Startup
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            XmlConfigurator.Configure();

            //BasicConfigurator.Configure();

            //log4net.Config.BasicConfigurator.Configure(
            //    new log4net.Appender.ConsoleAppender
            //    {
            //        Layout = new log4net.Layout.SimpleLayout()
            //    });
        }
    }
}
