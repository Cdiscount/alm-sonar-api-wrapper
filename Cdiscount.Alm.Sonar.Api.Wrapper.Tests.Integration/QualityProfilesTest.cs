using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Inheritance.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Tests.Integration
{
    [TestClass]
    public class QualityProfilesTest : SonarApiClientTest
    {
        private static SonarQualityProfilesSearch ListProfiles { get; set; }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            ListProfiles = SonarApiClient.QualityProfiles.Search();
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void QualityProfilesInheritanceCorrectArgs()
        {
            SonarApiClient.QualityProfiles.Inheritance(new SonarInheritanceArgs() { Language = "cs", ProfileName = "Alm" });
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        [ExpectedException(typeof(ArgumentException), "Either id or name must be set")]
        public void QualityProfilesInheritanceIncorrectArgs1()
        {
            SonarApiClient.QualityProfiles.Inheritance(new SonarInheritanceArgs());
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        [ExpectedException(typeof(ArgumentException), "Either id or name must be set")]
        public void QualityProfilesInheritanceIncorrectArgs2()
        {
            SonarApiClient.QualityProfiles.Inheritance(new SonarInheritanceArgs() { Language="cs"});
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        [ExpectedException(typeof(ArgumentException), "Either id or name must be set")]
        public void QualityProfilesInheritanceIncorrectArgs3()
        {
            SonarApiClient.QualityProfiles.Inheritance(new SonarInheritanceArgs() { ProfileName= "Alm" });
        }

    }
}