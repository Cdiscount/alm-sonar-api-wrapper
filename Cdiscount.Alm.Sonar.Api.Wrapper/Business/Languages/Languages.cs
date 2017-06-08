using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Languages.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Languages.Parameters;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Business.Languages
{
    /// <summary>
    /// Get the list of programming languages supported in this instance
    /// </summary>
    public class Languages : BaseObjectApi<Languages>
    {
        /// <summary>
        /// List supported programming languages
        /// </summary>
        /// <param name="sonarLanguagesListArgs">Arguments</param>
        /// <returns></returns>
        public SonarLanguagesList List(SonarLanguagesListArgs sonarLanguagesListArgs)
        {
            string url = string.Format("{0}api/languages/list{1}", SonarApiClient.BaseAddress, (sonarLanguagesListArgs == null)?String.Empty : sonarLanguagesListArgs.ToString());
            return SonarApiClient.QueryObject<SonarLanguagesList>(url);
        }
    }
}