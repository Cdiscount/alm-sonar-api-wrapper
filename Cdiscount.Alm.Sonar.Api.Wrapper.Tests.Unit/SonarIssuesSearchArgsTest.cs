using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Parameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Tests.Unit
{
    [TestClass()]
    public class SonarIssuesSearchArgsTest
    {
        [TestMethod()]
        public void ToStringTest()
        {
            var sonarIssuesSearchArgs = new SonarIssuesSearchArgs() { Assignees = new List<string>() { "julien.paules" }, AdditionalFields = new List<AdditionalField>() { AdditionalField.users, AdditionalField.rules, AdditionalField.languages } };
            Assert.AreEqual(sonarIssuesSearchArgs.ToString(), "?p=1&additionalFields=users,rules,languages,&assignees=julien.paules,");
        }
    }
}