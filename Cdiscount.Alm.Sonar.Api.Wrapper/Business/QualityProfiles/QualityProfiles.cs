using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Inheritance.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Inheritance.Response;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Business.QualityProfiles
{
    /// <summary>
    /// Represents a quality profile
    /// </summary>
    public class QualityProfiles : BaseObjectApi<QualityProfiles>
    {
        /// <summary>
        /// Get the list of QualityProfiles
        /// </summary>
        /// <returns></returns>
        public SonarQualityProfilesSearch Search()
        {
            string url = string.Format("{0}api/qualityprofiles/search", SonarApiClient.BaseAddress);
            return SonarApiClient.QueryObject<SonarQualityProfilesSearch>(url);
        }


        /// <summary>
        /// Get the inheritance of a quality profile
        /// </summary>
        /// <param name="profileKey">Key of the quality profile</param>
        /// <returns></returns>
        public SonarInheritance Inheritance(SonarInheritanceArgs sonarInheritanceArgs)
        {
            if (String.IsNullOrEmpty(sonarInheritanceArgs.ProfileKey) 
                && (String.IsNullOrEmpty(sonarInheritanceArgs.Language) || String.IsNullOrEmpty(sonarInheritanceArgs.ProfileName)))
            {
                throw new ArgumentException("Either quality profile key, or a combination of profileName + language must be set.");
            }
            string url = string.Format("{0}api/qualityprofiles/inheritance{1}", SonarApiClient.BaseAddress, sonarInheritanceArgs);
            return SonarApiClient.QueryObject<SonarInheritance>(url);
        }
    }
}