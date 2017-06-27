using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Parameters;
using System.Collections.Generic;
using System.Linq;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Response;
using System.Collections.Specialized;
using Microsoft.Extensions.Configuration;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Tests.Integration
{
    [TestClass]
    public class IssuesTest : SonarApiClientTest
    {
        public SonarIssuesSearchArgs SonarIssuesSearchArgs { get; set; }
        public SonarIssuesSearch Issues { get; set; }

        private void ResetIssuesbyArgs(NameValueCollection configuration)
        {
            Issues = SonarApiClient.Issues.Search(SonarIssuesSearchArgs, configuration);
        }
        private void ResetIssuesbyArgs(IConfigurationRoot configuration)
        {
            Issues = SonarApiClient.Issues.Search(SonarIssuesSearchArgs, configuration);
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void IssuesSearchWithAdditionalFieldsTest(NameValueCollection configuration)
        {
            SonarIssuesSearchArgs = new SonarIssuesSearchArgs() { AdditionalFields = new List<AdditionalField>() { AdditionalField.users, AdditionalField.rules, AdditionalField.languages } };
            ResetIssuesbyArgs(configuration);

            Assert.IsNotNull(Issues.Users);
            Assert.IsNotNull(Issues.Rules);
            Assert.IsNotNull(Issues.Languages);
        }

        public void IssuesSearchWithAdditionalFieldsTest(IConfigurationRoot configuration)
        {
            SonarIssuesSearchArgs = new SonarIssuesSearchArgs() { AdditionalFields = new List<AdditionalField>() { AdditionalField.users, AdditionalField.rules, AdditionalField.languages } };
            ResetIssuesbyArgs(configuration);

            Assert.IsNotNull(Issues.Users);
            Assert.IsNotNull(Issues.Rules);
            Assert.IsNotNull(Issues.Languages);
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void IssuesSearchWithoutAdditionalFieldsTest(NameValueCollection configuration)
        {
            SonarIssuesSearchArgs = new SonarIssuesSearchArgs();
            ResetIssuesbyArgs(configuration);

            Assert.IsNull(Issues.Users);
            Assert.IsNull(Issues.Rules);
            Assert.IsNull(Issues.Languages);
        }
        public void IssuesSearchWithoutAdditionalFieldsTest(IConfigurationRoot configuration)
        {
            SonarIssuesSearchArgs = new SonarIssuesSearchArgs();
            ResetIssuesbyArgs(configuration);

            Assert.IsNull(Issues.Users);
            Assert.IsNull(Issues.Rules);
            Assert.IsNull(Issues.Languages);
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void IssuesSearchAsyncTest(NameValueCollection configuration)
        {
            var issues = SonarApiClient.Issues.SearchAsync(SonarIssuesSearchArgs, configuration).GetAwaiter().GetResult();
            Assert.IsTrue(issues.Paging.Total > 0);
        }
        public void IssuesSearchAsyncTest(IConfigurationRoot configuration)
        {
            var issues = SonarApiClient.Issues.SearchAsync(SonarIssuesSearchArgs, configuration).GetAwaiter().GetResult();
            Assert.IsTrue(issues.Paging.Total > 0);
        }
    }
}