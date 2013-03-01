using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using me.joshbennett;

namespace JbOpenLauncherTest
{
    [TestClass]
    public class OpenLauncherTests
    {
        [TestMethod]
        public void DummyTest()
        {
            OpenLauncher ol = new OpenLauncher();
            Assert.IsTrue(true);
        }
    }
}
