using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using Cdiscount.Alm.Sonar.Api.Wrapper;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Projects.Response;
using System.Collections.Generic;

namespace ConfigCore
{

    class Program
    {
        static void Main(string[] args)
        {

            IConfigurationRoot configuration = GetConfig();

            SonarApiClient SonarClient = new SonarApiClient(configuration);
            List<SonarProject> projects = SonarClient.Projects.Index(null, configuration);

        }

        public static IConfigurationRoot GetConfig()
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .Build();

            return configuration;
        }


    }

}