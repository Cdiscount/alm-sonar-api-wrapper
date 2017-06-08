using Cdiscount.Alm.Sonar.Api.Wrapper.Core;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Rules.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Rules.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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

        private void ResetRulesResultByArgs()
        {
            RulesResult = SonarApiClient.Rules.Search(SonarRulesSearchArgs);
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void RulesTotalCSTest()
        {
            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Languages = new List<string>() { "cs"} };
            ResetRulesResultByArgs();

            // Because of the pagination, the test bellow concern only the rules of the current page (By default 100 rules per page)
            Assert.IsTrue(RulesResult.Rules.All(r => r.Lang == "cs"));
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void RulesTotalJavaTest()
        {
            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Languages = new List<string>() { "java" } };
            ResetRulesResultByArgs();

            // Because of the pagination, the test bellow concern only the rules of the current page (By default 100 rules per page)
            Assert.IsTrue(RulesResult.Rules.All(r => r.Lang == "java"));
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void RulesTotalJSTest()
        {
            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Languages = new List<string>() { "js" } };
            ResetRulesResultByArgs();

            // Because of the pagination, the test bellow concern only the rules of the current page (By default 100 rules per page)
            Assert.IsTrue(RulesResult.Rules.All(r => r.Lang == "js"));
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void RulesTotalByRepoTest()
        {
            int totalCommonCS, totalJS;
            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Repositories = new List<string>() { "common-cs" } };
            ResetRulesResultByArgs();
            totalCommonCS = RulesResult.Total;
            // Because of the pagination, the test bellow concern only the rules of the current page (By default 100 rules per page)
            Assert.IsTrue(RulesResult.Rules.All(r => r.Repo == "common-cs"));

            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Repositories = new List<string>() { "javascript" } };
            ResetRulesResultByArgs();
            totalJS = RulesResult.Total;
            // Because of the pagination, the test bellow concern only the rules of the current page (By default 100 rules per page)
            Assert.IsTrue(RulesResult.Rules.All(r => r.Repo == "javascript"));

            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Repositories = new List<string>() { "common-cs", "javascript" } };
            ResetRulesResultByArgs();
            Assert.AreEqual(totalCommonCS + totalJS, RulesResult.Total);
            // Because of the pagination, the test bellow concern only the rules of the current page (By default 100 rules per page)
            Assert.IsTrue(RulesResult.Rules.All(r => new List<string>() { "common-cs", "javascript" }.Contains(r.Repo)));
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        public void RulesSeverityParamsTest()
        {
            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Severities = new List<SonarSeverity>() { SonarSeverity.BLOCKER, SonarSeverity.CRITICAL } };
            ResetRulesResultByArgs();
            int total = RulesResult.Total;

            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Severities = new List<SonarSeverity>() { SonarSeverity.BLOCKER } };
            ResetRulesResultByArgs();
            int totalBLOCKER = RulesResult.Total;

            SonarRulesSearchArgs = new SonarRulesSearchArgs() { Severities = new List<SonarSeverity>() { SonarSeverity.CRITICAL } };
            ResetRulesResultByArgs();
            int totalCRITICAL = RulesResult.Total;

            Assert.AreEqual(total, totalBLOCKER+ totalCRITICAL);
        }
    }
}