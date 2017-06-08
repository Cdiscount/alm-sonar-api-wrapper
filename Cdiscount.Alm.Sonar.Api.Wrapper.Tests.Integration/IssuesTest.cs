using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Parameters;
using System.Collections.Generic;
using System.Linq;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Response;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Tests.Integration
{
    [TestClass]
    public class IssuesTest : SonarApiClientTest
    {
        public SonarIssuesSearchArgs SonarIssuesSearchArgs { get; set; }
        public SonarIssuesSearch Issues { get; set; }

        private void ResetIssuesbyArgs()
        {
            Issues = SonarApiClient.Issues.Search(SonarIssuesSearchArgs);
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void IssuesSearchWithAdditionalFieldsTest()
        {
            SonarIssuesSearchArgs = new SonarIssuesSearchArgs() { AdditionalFields = new List<AdditionalField>() { AdditionalField.users, AdditionalField.rules, AdditionalField.languages } };
            ResetIssuesbyArgs();

            Assert.IsNotNull(Issues.Users);
            Assert.IsNotNull(Issues.Rules);
            Assert.IsNotNull(Issues.Languages);
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void IssuesSearchWithoutAdditionalFieldsTest()
        {
            SonarIssuesSearchArgs = new SonarIssuesSearchArgs();
            ResetIssuesbyArgs();

            Assert.IsNull(Issues.Users);
            Assert.IsNull(Issues.Rules);
            Assert.IsNull(Issues.Languages);
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void IssuesSearchAsyncTest()
        {
            var issues = SonarApiClient.Issues.SearchAsync(SonarIssuesSearchArgs).GetAwaiter().GetResult();
            Assert.IsTrue(issues.Paging.Total > 0);
        }
    }
}