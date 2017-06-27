using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Specialized;
using Microsoft.Extensions.Configuration;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Tests.Integration
{
    [TestClass]
    public abstract class SonarApiClientTest
    {
        protected static SonarApiClient SonarApiClient { get; set; }

        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context, NameValueCollection configuration)
        {
            SonarApiClient = new SonarApiClient(configuration);
        }

        public static void AssemblyInit(TestContext context, IConfigurationRoot configuration)
        {
            SonarApiClient = new SonarApiClient(configuration);
        }

        [TestCleanup]
        public void TearDown()
        {
            // Method intentionally left empty.
        }
    }
}