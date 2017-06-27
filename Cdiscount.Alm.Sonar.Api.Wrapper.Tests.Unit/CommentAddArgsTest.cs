using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Comments.Parameters;
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
    public class CommentAddArgsTest
    {
        [TestMethod()]
        public void ToStringTest()
        {
            var commentAddArg = new CommentAddArgs();
            commentAddArg.IssueKey = "AVsO7kf-i5ZDPiGMv5yC";
            commentAddArg.Text = "i'm commenting this issue.";

            Assert.AreEqual(commentAddArg.ToString(), string.Format("issue=AVsO7kf-i5ZDPiGMv5yC&text={0}&format=json", HttpUtility.UrlEncode("i'm commenting this issue.")));
        }
    }
}