using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityGates.Parameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
        public void QualityGateShowIncorrectArgs()
        {
            SonarApiClient.QualityGates.Show(new SonarQualityGateShowArgs());
        }
    }
}