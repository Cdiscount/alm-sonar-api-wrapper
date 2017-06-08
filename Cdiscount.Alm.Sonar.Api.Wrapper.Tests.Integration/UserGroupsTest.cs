using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Users.Groups.Parameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
        public void UserGroupsUsersNullArgumentExceptionTest()
        {
            SonarApiClient.UserGroups.Users(null);
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        [ExpectedException(typeof(ArgumentException), "Group name or group id must be provided, not both.")]
        public void UserGroupsUsersArgumentExceptionTest()
        {
            SonarApiClient.UserGroups.Users(new SonarUserGroupsUsersArgs());
        }

        [TestMethod]
        [TestCategory(Constants.IntegrationCategoryTest)]
        [ExpectedException(typeof(ArgumentException), "Group name or group id must be provided, not both.")]
        public void UserGroupsUsersArgumentBothExceptionTest()
        {
            SonarApiClient.UserGroups.Users(new SonarUserGroupsUsersArgs() { Id = 3, Name = "test" });
        }
    }
}