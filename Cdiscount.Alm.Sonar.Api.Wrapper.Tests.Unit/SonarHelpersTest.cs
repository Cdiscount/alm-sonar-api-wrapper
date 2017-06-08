using Cdiscount.Alm.Sonar.Api.Wrapper.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Tests.Unit
{
    [TestClass()]
    public class SonarHelpersTest
    {
        [TestMethod()]
        public void FormatDateForSonarIso8601Test()
        {
            DateTime myDate = new DateTime(2013, 05, 01, 13, 0, 0);
            string expectedDateFormated = string.Format("2013-05-01T13:00:00+0{0}00", (myDate.ToLocalTime() - myDate).TotalHours); //to have french hour
            Assert.AreEqual(expectedDateFormated, SonarHelpers.FormatDateForSonarIso8601(myDate));
        }

        [TestMethod()]
        public void AppendUrlTest()
        {
            //1st signature
            var url = GetUrl();
            string parameterName = "assigned";
            string parameterValue = "julien.paules";
            string expectedValue = "http://sonarUrl/api/issues/&assigned=julien.paules";

            SonarHelpers.AppendUrl(url, parameterName, parameterValue);

            Assert.AreEqual(expectedValue, url.ToString());

            //2nd signature
            url = GetUrl();
            parameterName = "tags";
            List<string> parameterValues = new List<string>() { "technical-debt", "fooTag" };
            expectedValue = "http://sonarUrl/api/issues/&tags=technical-debt,fooTag,";

            SonarHelpers.AppendUrl(url, parameterName, parameterValues);

            Assert.AreEqual(expectedValue, url.ToString());

            //3rd signature
            url = GetUrl();
            parameterName = "additionalFields";
            List<Core.Issues.Parameters.AdditionalField> parameterValuesGeneric = new List<Core.Issues.Parameters.AdditionalField>() { Core.Issues.Parameters.AdditionalField.actions, Core.Issues.Parameters.AdditionalField.comments };
            expectedValue = "http://sonarUrl/api/issues/&additionalFields=actions,comments,";

            SonarHelpers.AppendUrl<Core.Issues.Parameters.AdditionalField>(url, parameterName, parameterValuesGeneric);

            Assert.AreEqual(expectedValue, url.ToString());
        }

        private static StringBuilder GetUrl()
        {
            return new StringBuilder("http://sonarUrl/api/issues/");
        }
    }
}