using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Users.Groups.Parameters;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Tests.Integration
{
    [TestClass]
    public class UserGroupsTest : SonarApiClientTest
    {
        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        [ExpectedException(typeof(ArgumentException), "The argument can't be null.")]
        public void UserGroupsUsersNullArgumentExceptionTest(IConfigurationRoot configuration)
        {
            SonarApiClient.UserGroups.Users(null, configuration);
        }
        public void UserGroupsUsersNullArgumentExceptionTest(NameValueCollection configuration)
        {
            SonarApiClient.UserGroups.Users(null, configuration);
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        [ExpectedException(typeof(ArgumentException), "Group name or group id must be provided, not both.")]
        public void UserGroupsUsersArgumentExceptionTest(IConfigurationRoot configuration)
        {
            SonarApiClient.UserGroups.Users(new SonarUserGroupsUsersArgs(), configuration);
        }
        public void UserGroupsUsersArgumentExceptionTest(NameValueCollection configuration)
        {
            SonarApiClient.UserGroups.Users(new SonarUserGroupsUsersArgs(), configuration);
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        [ExpectedException(typeof(ArgumentException), "Group name or group id must be provided, not both.")]
        public void UserGroupsUsersArgumentBothExceptionTest(IConfigurationRoot configuration)
        {
            SonarApiClient.UserGroups.Users(new SonarUserGroupsUsersArgs() { Id = 3, Name = "test" }, configuration);
        }
        public void UserGroupsUsersArgumentBothExceptionTest(NameValueCollection configuration)
        {
            SonarApiClient.UserGroups.Users(new SonarUserGroupsUsersArgs() { Id = 3, Name = "test" }, configuration);
        }
    }
}