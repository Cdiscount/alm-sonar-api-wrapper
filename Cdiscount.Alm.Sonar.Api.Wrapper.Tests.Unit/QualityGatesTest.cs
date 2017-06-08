using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Comments.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityGates.Parameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Tests.Unit
{
    [TestClass()]
    public class QualityGatesTest 
    {
        #region Show

        [TestMethod()]
        public void QualityGateShowArgsToStringTest()
        {
            var args = new SonarQualityGateShowArgs(1, "toto");
            Assert.AreEqual(args.ToString(), "?id=1&name=toto");

            args = new SonarQualityGateShowArgs(null, "toto");
            Assert.AreEqual(args.ToString(), "?name=toto");

            args = new SonarQualityGateShowArgs(1);
            Assert.AreEqual(args.ToString(), "?id=1");
        }

        #endregion Show

        #region Search

        [TestMethod()]
        public void QualityGateSearchArgsToStringTest()
        {
            var args = new SonarQualityGatesSearchArgs(1);
            Assert.AreEqual(args.ToString(), "?gateId=1&page=1&pageSize=100&selected=selected");

            args = new SonarQualityGatesSearchArgs(1) { Page = 2, Selected = SelectedValues.deselected };
            Assert.AreEqual(args.ToString(), "?gateId=1&page=2&pageSize=100&selected=deselected");

            args = new SonarQualityGatesSearchArgs(1) { Page = 3, PageSize = 50, Query = "toto" };
            Assert.AreEqual(args.ToString(), String.Format("?gateId=1&page=3&pageSize=50&query={0}&selected=selected", HttpUtility.UrlEncode("toto")));
        }

        #endregion Search
    }
}