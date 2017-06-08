using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Tests.Integration
{
    [TestClass]
    public class SystemTest : SonarApiClientTest
    {
        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void SystemStatusTest()
        {
            var status = SonarApiClient.System.Status();

            Assert.AreEqual(status.Status, "UP");
            Assert.AreEqual(status.Version, "5.6.6");
        }
    }
}