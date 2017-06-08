using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Plugins.Parameters
{
    public enum AdditionalFieldsValues
    {
        category
    }

    /// <summary>
    /// Arguments to get the list of plugins installed
    /// </summary>
    public class SonarPluginsInstalledArgs
    {
        public SonarPluginsInstalledArgs()
        {
            AdditionalFields = new List<AdditionalFieldsValues>();
        }

        /// <summary>
        /// Comma-separated list of the additional fields to be returned in response. No additional field is returned by default
        /// </summary>
        public List<AdditionalFieldsValues> AdditionalFields { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            SonarHelpers.AppendUrl(result, "f", AdditionalFields);

            return result.Length > 0 ? "?" + result : string.Empty;
        }
    }
}