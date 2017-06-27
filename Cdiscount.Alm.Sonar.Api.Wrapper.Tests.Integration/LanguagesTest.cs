using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Languages.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Languages.Response;
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
    public class LanguagesTest : SonarApiClientTest
    {
        private SonarLanguagesListArgs SonarLanguagesListArgs { get; set; }
        private SonarLanguagesList LanguagesList { get; set; }

        private void ResetLanguagesListByArgs(IConfigurationRoot configuration)
        {
            LanguagesList = SonarApiClient.Languages.List(SonarLanguagesListArgs, configuration);
        }
        private void ResetLanguagesListByArgs(NameValueCollection configuration)
        {
            LanguagesList = SonarApiClient.Languages.List(SonarLanguagesListArgs, configuration);
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void LanguagesListTestPageSize(IConfigurationRoot configuration)
        {
            SonarLanguagesListArgs = new SonarLanguagesListArgs(2, null);
            ResetLanguagesListByArgs(configuration);

            Assert.AreEqual(LanguagesList.Languages.Count, 2);
        }
        public void LanguagesListTestPageSize(NameValueCollection configuration)
        {
            SonarLanguagesListArgs = new SonarLanguagesListArgs(2, null);
            ResetLanguagesListByArgs(configuration);

            Assert.AreEqual(LanguagesList.Languages.Count, 2);
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void LanguagesCSTest(IConfigurationRoot configuration)
        {
            SonarLanguagesListArgs = new SonarLanguagesListArgs(0, "cs");
            ResetLanguagesListByArgs(configuration);

            Assert.AreEqual(LanguagesList.Languages.Count, 1);
            Assert.AreEqual(LanguagesList.Languages.First().Key, "cs");
            Assert.AreEqual(LanguagesList.Languages.First().Name, "C#");
        }
        public void LanguagesCSTest(NameValueCollection configuration)
        {
            SonarLanguagesListArgs = new SonarLanguagesListArgs(0, "cs");
            ResetLanguagesListByArgs(configuration);

            Assert.AreEqual(LanguagesList.Languages.Count, 1);
            Assert.AreEqual(LanguagesList.Languages.First().Key, "cs");
            Assert.AreEqual(LanguagesList.Languages.First().Name, "C#");
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void LanguagesJavaTest(IConfigurationRoot configuration)
        {
            SonarLanguagesListArgs = new SonarLanguagesListArgs(0, "java");
            ResetLanguagesListByArgs(configuration);

            Assert.AreEqual(LanguagesList.Languages.Count, 2);// Java and Javascript
            Assert.IsTrue(LanguagesList.Languages.Any(l => l.Name == "Java"));
            Assert.IsTrue(LanguagesList.Languages.Any(l => l.Name == "JavaScript"));
        }
        public void LanguagesJavaTest(NameValueCollection configuration)
        {
            SonarLanguagesListArgs = new SonarLanguagesListArgs(0, "java");
            ResetLanguagesListByArgs(configuration);

            Assert.AreEqual(LanguagesList.Languages.Count, 2);// Java and Javascript
            Assert.IsTrue(LanguagesList.Languages.Any(l => l.Name == "Java"));
            Assert.IsTrue(LanguagesList.Languages.Any(l => l.Name == "JavaScript"));
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void LanguagesJSTest(IConfigurationRoot configuration)
        {
            SonarLanguagesListArgs = new SonarLanguagesListArgs(0, "js");
            ResetLanguagesListByArgs(configuration);

            Assert.AreEqual(LanguagesList.Languages.Count, 1);
            Assert.AreEqual(LanguagesList.Languages.First().Key, "js");
            Assert.AreEqual(LanguagesList.Languages.First().Name, "JavaScript");
        }
        public void LanguagesJSTest(NameValueCollection configuration)
        {
            SonarLanguagesListArgs = new SonarLanguagesListArgs(0, "js");
            ResetLanguagesListByArgs(configuration);

            Assert.AreEqual(LanguagesList.Languages.Count, 1);
            Assert.AreEqual(LanguagesList.Languages.First().Key, "js");
            Assert.AreEqual(LanguagesList.Languages.First().Name, "JavaScript");
        }
    }
}