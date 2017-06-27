using Cdiscount.Alm.Sonar.Api.Wrapper.Core;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Rules.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Rules.Response;
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

    public class RulesTest : SonarApiClientTest
    {
        private SonarRulesSearchArgs SonarRulesSearchArgs { get; set; }
        private SonarRulesSearch RulesResult { get; set; }

        private void ResetRulesResultByArgs(IConfigurationRoot configuration)
        {
            RulesResult = SonarApiClient.Rules.Search(SonarRulesSearchArgs, configuration);
        }
        private void ResetRulesResultByArgs(NameValueCollection configuration)
        {
            RulesResult = SonarApiClient.Rules.Search(SonarRulesSearchArgs, configuration);
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void RulesTotalCSTest(IConfigurationRoot configuration)
        {
            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Languages = new List<string>() { "cs"} };
            ResetRulesResultByArgs(configuration);

            // Because of the pagination, the test bellow concern only the rules of the current page (By default 100 rules per page)
            Assert.IsTrue(RulesResult.Rules.All(r => r.Lang == "cs"));
        }
        public void RulesTotalCSTest(NameValueCollection configuration)
        {
            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Languages = new List<string>() { "cs" } };
            ResetRulesResultByArgs(configuration);

            // Because of the pagination, the test bellow concern only the rules of the current page (By default 100 rules per page)
            Assert.IsTrue(RulesResult.Rules.All(r => r.Lang == "cs"));
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void RulesTotalJavaTest(IConfigurationRoot configuration)
        {
            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Languages = new List<string>() { "java" } };
            ResetRulesResultByArgs(configuration);

            // Because of the pagination, the test bellow concern only the rules of the current page (By default 100 rules per page)
            Assert.IsTrue(RulesResult.Rules.All(r => r.Lang == "java"));
        }
        public void RulesTotalJavaTest(NameValueCollection configuration)
        {
            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Languages = new List<string>() { "java" } };
            ResetRulesResultByArgs(configuration);

            // Because of the pagination, the test bellow concern only the rules of the current page (By default 100 rules per page)
            Assert.IsTrue(RulesResult.Rules.All(r => r.Lang == "java"));
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void RulesTotalJSTest(IConfigurationRoot configuration)
        {
            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Languages = new List<string>() { "js" } };
            ResetRulesResultByArgs(configuration);

            // Because of the pagination, the test bellow concern only the rules of the current page (By default 100 rules per page)
            Assert.IsTrue(RulesResult.Rules.All(r => r.Lang == "js"));
        }
        public void RulesTotalJSTest(NameValueCollection configuration)
        {
            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Languages = new List<string>() { "js" } };
            ResetRulesResultByArgs(configuration);

            // Because of the pagination, the test bellow concern only the rules of the current page (By default 100 rules per page)
            Assert.IsTrue(RulesResult.Rules.All(r => r.Lang == "js"));
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void RulesTotalByRepoTest(IConfigurationRoot configuration)
        {
            int totalCommonCS, totalJS;
            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Repositories = new List<string>() { "common-cs" } };
            ResetRulesResultByArgs(configuration);
            totalCommonCS = RulesResult.Total;
            // Because of the pagination, the test bellow concern only the rules of the current page (By default 100 rules per page)
            Assert.IsTrue(RulesResult.Rules.All(r => r.Repo == "common-cs"));

            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Repositories = new List<string>() { "javascript" } };
            ResetRulesResultByArgs(configuration);
            totalJS = RulesResult.Total;
            // Because of the pagination, the test bellow concern only the rules of the current page (By default 100 rules per page)
            Assert.IsTrue(RulesResult.Rules.All(r => r.Repo == "javascript"));

            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Repositories = new List<string>() { "common-cs", "javascript" } };
            ResetRulesResultByArgs(configuration);
            Assert.AreEqual(totalCommonCS + totalJS, RulesResult.Total);
            // Because of the pagination, the test bellow concern only the rules of the current page (By default 100 rules per page)
            Assert.IsTrue(RulesResult.Rules.All(r => new List<string>() { "common-cs", "javascript" }.Contains(r.Repo)));
        }
        public void RulesTotalByRepoTest(NameValueCollection configuration)
        {
            int totalCommonCS, totalJS;
            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Repositories = new List<string>() { "common-cs" } };
            ResetRulesResultByArgs(configuration);
            totalCommonCS = RulesResult.Total;
            // Because of the pagination, the test bellow concern only the rules of the current page (By default 100 rules per page)
            Assert.IsTrue(RulesResult.Rules.All(r => r.Repo == "common-cs"));

            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Repositories = new List<string>() { "javascript" } };
            ResetRulesResultByArgs(configuration);
            totalJS = RulesResult.Total;
            // Because of the pagination, the test bellow concern only the rules of the current page (By default 100 rules per page)
            Assert.IsTrue(RulesResult.Rules.All(r => r.Repo == "javascript"));

            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Repositories = new List<string>() { "common-cs", "javascript" } };
            ResetRulesResultByArgs(configuration);
            Assert.AreEqual(totalCommonCS + totalJS, RulesResult.Total);
            // Because of the pagination, the test bellow concern only the rules of the current page (By default 100 rules per page)
            Assert.IsTrue(RulesResult.Rules.All(r => new List<string>() { "common-cs", "javascript" }.Contains(r.Repo)));
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void RulesSeverityParamsTest(IConfigurationRoot configuration)
        {
            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Severities = new List<SonarSeverity>() { SonarSeverity.BLOCKER, SonarSeverity.CRITICAL } };
            ResetRulesResultByArgs(configuration);
            int total = RulesResult.Total;

            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Severities = new List<SonarSeverity>() { SonarSeverity.BLOCKER } };
            ResetRulesResultByArgs(configuration);
            int totalBLOCKER = RulesResult.Total;

            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Severities = new List<SonarSeverity>() { SonarSeverity.CRITICAL } };
            ResetRulesResultByArgs(configuration);
            int totalCRITICAL = RulesResult.Total;

            Assert.AreEqual(total, totalBLOCKER+ totalCRITICAL);
        }
        public void RulesSeverityParamsTest(NameValueCollection configuration)
        {
            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Severities = new List<SonarSeverity>() { SonarSeverity.BLOCKER, SonarSeverity.CRITICAL } };
            ResetRulesResultByArgs(configuration);
            int total = RulesResult.Total;

            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Severities = new List<SonarSeverity>() { SonarSeverity.BLOCKER } };
            ResetRulesResultByArgs(configuration);
            int totalBLOCKER = RulesResult.Total;

            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Severities = new List<SonarSeverity>() { SonarSeverity.CRITICAL } };
            ResetRulesResultByArgs(configuration);
            int totalCRITICAL = RulesResult.Total;

            Assert.AreEqual(total, totalBLOCKER + totalCRITICAL);
        }

    }
}