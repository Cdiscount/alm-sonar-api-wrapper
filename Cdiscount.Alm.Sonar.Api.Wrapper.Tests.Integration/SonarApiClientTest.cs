using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Tests.Integration
{
    [TestClass]
    public abstract class SonarApiClientTest
    {
        protected static SonarApiClient SonarApiClient { get; set; }

        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            SonarApiClient = new SonarApiClient();
        }

        [TestCleanup]
        public void TearDown()
        {
            // Method intentionally left empty.
        }
    }
}