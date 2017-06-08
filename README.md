# Welcome to the ALM Sonar API Wrapper project #
# Overview #

This repository contains tools to help integrate SonarQube API. This solution create a nuget package you can use in your custom .NET solutions to connect to Sonar
The package is available on **nuget.org** with the Id **Cdiscount.Alm.Sonar.Api.Wrapper**

# Configuration #
You must congigure the **app.config** with your connection settings :
 - add key="SonarApiUri" value="{yourSonarUri}"
 - add key="SonarApiToken" value="{YourToken}"

# Projects #
**Cdiscount.Alm.Sonar.Api.Wrapper**

In this project, you can find the client wrapper to connect to Sonar. This project creates the nuget package *Cdiscount.Alm.Sonar.Api.Wrapper.nupkg*

**Cdiscount.Alm.Sonar.Api.Wrapper.Core**

In this project, you can find object represent Sonar entities (Parameters and Response)

**Cdiscount.Alm.Sonar.Api.Wrapper.Tests.Integration**

Integration tests are executed on the Sonar Uri. 
This tests need the App.config of the Tests.Integration project to be configured (by setting SonarApiUri and SonarApiToken) 


**Cdiscount.Alm.Sonar.Api.Wrapper.Tests.Unit**

In this project, you can find unit tests definition. There are two kind of unit tests: 
 - Unit tests used to check development integrity
 - Unit tests used to ensure homogeneity between each Cdiscount team developments


# Build #

The build workflow ensure :
 - Nuget package restore
 - Sonar connection
 - MS Build
 - Unit test validation
 - Publish package
 
# Release #

Specifically, the release will generate the nuget package *Cdiscount.Alm.Sonar.Api.Wrapper.nupkg* 

# How to contribute? #

**The process**
 
 Before contributing, please check if your new development has not been already developed
 1. Create branch from the Master branch 
 2. Develop on the new branche
 3. Pull request your new development to an ALM team member
 4. ALM valid (or indicate if the code needs work)
 5. Your branch is merged to the Master branch and your branch is destroyed
 
 
**Hints**
 
 ##How to use TFS Git ?
 https://blogs.msdn.microsoft.com/visualstudioalm/2013/01/30/getting-started-with-git-in-visual-studio-and-team-foundation-service/
 
 ##How to pull request ?
 https://www.visualstudio.com/en-us/docs/git/pull-requests 

   
   
   
