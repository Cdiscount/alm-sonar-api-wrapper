using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityGates.Parameters;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Tests.Integration
{
    [TestClass]
    public class QualityGatesTest : SonarApiClientTest
    {
        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        [ExpectedException(typeof(ArgumentException), "Either id or name must be set")]
        public void QualityGateShowIncorrectArgs(IConfigurationRoot configuration)
        {
            SonarApiClient.QualityGates.Show(new SonarQualityGateShowArgs(), configuration);
        }
        public void QualityGateShowIncorrectArgs(NameValueCollection configuration)
        {
            SonarApiClient.QualityGates.Show(new SonarQualityGateShowArgs(), configuration);
        }
    }
}