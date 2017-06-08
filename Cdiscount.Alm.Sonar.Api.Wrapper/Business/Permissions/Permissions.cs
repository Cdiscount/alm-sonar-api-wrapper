using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Permissions.Global.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Permissions.Project.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Permissions.Project.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Permissions.Template.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Permissions.Template.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Business.Permissions
{
    /// <summary>
    /// Manage permission templates
    /// </summary>
    public class Permissions : BaseObjectApi<Permissions>
    {
        /// <summary>
        /// List global permissions
        /// </summary>
        /// <returns></returns>
        public SonarPermissionsSearchGlobal SearchGlobal()
        {
            string url = string.Format("{0}api/permissions/search_global_permissions", SonarApiClient.BaseAddress);
            return SonarApiClient.QueryObject<SonarPermissionsSearchGlobal>(url);
        }

        /// <summary>
        /// List project permissions. A project can be a technical project, a view or a developer
        /// </summary>
        /// <param name="sonarPermissionsSearchProjectArgs"></param>
        /// <returns></returns>
        public SonarPermissionsSearchProject SearchProject(SonarPermissionsSearchProjectArgs sonarPermissionsSearchProjectArgs)
        {
            string url = string.Format("{0}api/permissions/search_project_permissions{1}", SonarApiClient.BaseAddress
                , (sonarPermissionsSearchProjectArgs == null) ? String.Empty : sonarPermissionsSearchProjectArgs.ToString());
            return SonarApiClient.QueryObject<SonarPermissionsSearchProject>(url);
        }

        public SonarPermissionsSearchProject SearchProject()
        {
            return SearchProject(null);
        }

        /// <summary>
        /// List permission templates
        /// </summary>
        /// <param name="sonarPermissionsSearchTemplatesArgs"></param>
        /// <returns></returns>
        public SonarPermissionsSearchTemplates SearchTemplate(SonarPermissionsSearchTemplatesArgs sonarPermissionsSearchTemplatesArgs)
        {
            string url = string.Format("{0}api/permissions/search_templates{1}", SonarApiClient.BaseAddress
                , (sonarPermissionsSearchTemplatesArgs == null) ? String.Empty : sonarPermissionsSearchTemplatesArgs.ToString());
            return SonarApiClient.QueryObject<SonarPermissionsSearchTemplates>(url);
        }

        public SonarPermissionsSearchTemplates SearchTemplate()
        {
            return SearchTemplate(null);
        }
    }
}