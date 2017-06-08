using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Languages.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Languages.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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

        private void ResetLanguagesListByArgs()
        {
            LanguagesList = SonarApiClient.Languages.List(SonarLanguagesListArgs);
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void LanguagesListTestPageSize()
        {
            SonarLanguagesListArgs = new SonarLanguagesListArgs(2, null);
            ResetLanguagesListByArgs();

            Assert.AreEqual(LanguagesList.Languages.Count, 2);
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void LanguagesCSTest()
        {
            SonarLanguagesListArgs = new SonarLanguagesListArgs(0, "cs");
            ResetLanguagesListByArgs();

            Assert.AreEqual(LanguagesList.Languages.Count, 1);
            Assert.AreEqual(LanguagesList.Languages.First().Key, "cs");
            Assert.AreEqual(LanguagesList.Languages.First().Name, "C#");
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void LanguagesJavaTest()
        {
            SonarLanguagesListArgs = new SonarLanguagesListArgs(0, "java");
            ResetLanguagesListByArgs();

            Assert.AreEqual(LanguagesList.Languages.Count, 2);// Java and Javascript
            Assert.IsTrue(LanguagesList.Languages.Any(l => l.Name == "Java"));
            Assert.IsTrue(LanguagesList.Languages.Any(l => l.Name == "JavaScript"));
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void LanguagesJSTest()
        {
            SonarLanguagesListArgs = new SonarLanguagesListArgs(0, "js");
            ResetLanguagesListByArgs();

            Assert.AreEqual(LanguagesList.Languages.Count, 1);
            Assert.AreEqual(LanguagesList.Languages.First().Key, "js");
            Assert.AreEqual(LanguagesList.Languages.First().Name, "JavaScript");
        }
    }
}