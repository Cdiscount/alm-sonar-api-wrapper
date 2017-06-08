using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Plugins.Parameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Tests.Unit
{
    [TestClass()]
    public class SonarPluginsArgsTest
    {
        [TestMethod()]
        public void SonarPluginsArgsToStringTest()
        {
            SonarPluginsInstalledArgs args = new SonarPluginsInstalledArgs();
            Assert.AreEqual(args.ToString(), String.Empty);

            args.AdditionalFields = new List<AdditionalFieldsValues>() { AdditionalFieldsValues.category };
            Assert.AreEqual(args.ToString(), string.Format("?f={0},", AdditionalFieldsValues.category.ToString()));
        }
    }
}