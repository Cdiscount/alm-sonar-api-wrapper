using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cdiscount.Alm.Sonar.Api.Wrapper;
using Cdiscount.Alm.Sonar.Api.Wrapper.Business.Projects;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Projects.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Projects.Parameters;

namespace ConfigFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            NameValueCollection parameters = ConfigurationManager.AppSettings;

            SonarApiClient SonarClient = new SonarApiClient(parameters);
            List<SonarProject> projects = SonarClient.Projects.Index(null,parameters);        
        }

    }
}
