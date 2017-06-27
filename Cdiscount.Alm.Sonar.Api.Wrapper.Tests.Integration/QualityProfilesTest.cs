using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Inheritance.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        public static void ClassInit(TestContext context, IConfigurationRoot configuration)
        {
            ListProfiles = SonarApiClient.QualityProfiles.Search(configuration);
        }
        public static void ClassInit(TestContext context, NameValueCollection configuration)
        {
            ListProfiles = SonarApiClient.QualityProfiles.Search(configuration);
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void QualityProfilesInheritanceCorrectArgs(IConfigurationRoot configuration)
        {
            SonarApiClient.QualityProfiles.Inheritance(new SonarInheritanceArgs() { Language = "cs", ProfileName = "Alm" }, configuration);
        }
        public void QualityProfilesInheritanceCorrectArgs(NameValueCollection configuration)
        {
            SonarApiClient.QualityProfiles.Inheritance(new SonarInheritanceArgs() { Language = "cs", ProfileName = "Alm" }, configuration);
        }


        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        [ExpectedException(typeof(ArgumentException), "Either id or name must be set")]
        public void QualityProfilesInheritanceIncorrectArgs1(IConfigurationRoot configuration)
        {
            SonarApiClient.QualityProfiles.Inheritance(new SonarInheritanceArgs(), configuration);
        }
        public void QualityProfilesInheritanceIncorrectArgs1(NameValueCollection configuration)
        {
            SonarApiClient.QualityProfiles.Inheritance(new SonarInheritanceArgs(), configuration);
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        [ExpectedException(typeof(ArgumentException), "Either id or name must be set")]
        public void QualityProfilesInheritanceIncorrectArgs2(IConfigurationRoot configuration)
        {
            SonarApiClient.QualityProfiles.Inheritance(new SonarInheritanceArgs() { Language="cs"}, configuration);
        }
        public void QualityProfilesInheritanceIncorrectArgs2(NameValueCollection configuration)
        {
            SonarApiClient.QualityProfiles.Inheritance(new SonarInheritanceArgs() { Language = "cs" }, configuration);
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        [ExpectedException(typeof(ArgumentException), "Either id or name must be set")]
        public void QualityProfilesInheritanceIncorrectArgs3(IConfigurationRoot configuration)
        {
            SonarApiClient.QualityProfiles.Inheritance(new SonarInheritanceArgs() { ProfileName= "Alm" }, configuration);
        }
        public void QualityProfilesInheritanceIncorrectArgs3(NameValueCollection configuration)
        {
            SonarApiClient.QualityProfiles.Inheritance(new SonarInheritanceArgs() { ProfileName = "Alm" }, configuration);
        }

    }
}