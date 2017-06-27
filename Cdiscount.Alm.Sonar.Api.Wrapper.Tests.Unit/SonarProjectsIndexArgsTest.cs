using Cdiscount.Alm.Sonar.Api.Wrapper.Core;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Projects.Parameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Tests.Unit
{
    [TestClass()]
    public class SonarProjectsIndexArgsTest
    {
        [TestMethod()]
        public void SonarProjectsIndexArgsToStringTest()
        {


            var args = new SonarProjectsIndexArgs()
            {
                Desc = false,
                Key = "testKey",
                Libs = true,
                Search = "toto",
                Subprojects = false,
                Versions = VersionsValues._false,
                Views = true
            };    

            Assert.AreEqual(args.ToString(), string.Format("?desc={0}&format={1}&key={2}&libs={3}&search={4}&subprojects={5}&versions={6}&views={7}"
                , "false", Constants.Format.Json, "testKey", "true", "toto", "false", "false", "true"));
        }

    }
}