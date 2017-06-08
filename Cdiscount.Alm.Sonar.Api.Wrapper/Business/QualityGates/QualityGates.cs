using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityGates.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityGates.Parameters;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Business.QualityGates
{
    /// <summary>
    /// Manage quality gates, including conditions and project association
    /// </summary>
    public class QualityGates : BaseObjectApi<QualityGates>
    {
        /// <summary>
        /// Get a list of quality gates
        /// </summary>
        /// <returns></returns>
        public SonarQualityGatesList List()
        {
            string url = string.Format("{0}api/qualitygates/list", SonarApiClient.BaseAddress);
            return SonarApiClient.QueryObject<SonarQualityGatesList>(url);
        }

        /// <summary>
        /// Display the details of a quality gate
        /// </summary>
        /// <param name="sonarQualityGateShowArgs"></param>
        /// <returns></returns>
        public SonarQualityGateShow Show(SonarQualityGateShowArgs sonarQualityGateShowArgs)
        {
            if (!sonarQualityGateShowArgs.Id.HasValue && String.IsNullOrEmpty(sonarQualityGateShowArgs.Name))
            {
                throw new ArgumentException("Either id or name must be set");
            }
            string url = string.Format("{0}api/qualitygates/show{1}", SonarApiClient.BaseAddress, sonarQualityGateShowArgs);
            return SonarApiClient.QueryObject<SonarQualityGateShow>(url);
        }

        /// <summary>
        /// Search for projects associated (or not) to a quality gate.
        /// Only authorized projects for current user will be returned.
        /// </summary>
        /// <param name="sonarQualityGatesSearchArgs"></param>
        /// <returns></returns>
        public SonarQualityGatesSearch Search(SonarQualityGatesSearchArgs sonarQualityGatesSearchArgs)
        {
            string url = string.Format("{0}api/qualitygates/search{1}", SonarApiClient.BaseAddress, sonarQualityGatesSearchArgs);
            return SonarApiClient.QueryObject<SonarQualityGatesSearch>(url);
        }
    }
}