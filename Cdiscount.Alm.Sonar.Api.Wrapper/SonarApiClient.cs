using Cdiscount.Alm.Sonar.Api.Wrapper.Business;
using Cdiscount.Alm.Sonar.Api.Wrapper.Business.Issues.Filters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Business.Issues;
using Cdiscount.Alm.Sonar.Api.Wrapper.Business.Languages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Cdiscount.Alm.Sonar.Api.Wrapper.Business.Rules;
using Cdiscount.Alm.Sonar.Api.Wrapper.Business.QualityProfiles;
using Cdiscount.Alm.Sonar.Api.Wrapper.Business.QualityGates;
using Cdiscount.Alm.Sonar.Api.Wrapper.Business.Projects;
using Cdiscount.Alm.Sonar.Api.Wrapper.Business.Plugins;
using Cdiscount.Alm.Sonar.Api.Wrapper.Business.Users;
using Cdiscount.Alm.Sonar.Api.Wrapper.Business.Users.Groups;
using Cdiscount.Alm.Sonar.Api.Wrapper.Business.Permissions;
using Cdiscount.Alm.Sonar.Api.Wrapper.Business.Metrics;

namespace Cdiscount.Alm.Sonar.Api.Wrapper
{
    /// <summary>
    /// Simple client for calling the Sonar API.
    /// note: a cool site to generate json classes: http://json2csharp.com/
    /// </summary>
    public class SonarApiClient
    {
        #region attributes

        private readonly string _baseAddress;

        // used for paged searches
        private readonly Issues _issues;
        private readonly Business.System.System _system;
        private readonly Filters _filters;
        private readonly Languages _languages;
        private readonly Rules _rules;
        private readonly QualityProfiles _qualityProfiles;
        private readonly QualityGates _qualityGates;
        private readonly Projects _projects;
        private readonly Plugins _plugins;
        private readonly Users _users;
        private readonly UserGroups _userGroups;
        private readonly Permissions _permissions;
        private readonly Metrics _metrics;

        #endregion attributes

        #region Constructors

        /// <summary>
        /// Sonar Api client constructor. One instance per Sonar server address.
        /// </summary>
        /// <param name="baseAddress">The Uri of the server Sonar API</param>
        public SonarApiClient(Uri baseAddress)
        {
            _baseAddress = baseAddress.AbsoluteUri;
            _issues = BaseObjectApi<Issues>.CreateObject(this);
            _system = BaseObjectApi<Business.System.System>.CreateObject(this);
            _filters = BaseObjectApi<Filters>.CreateObject(this);
            _languages = BaseObjectApi<Languages>.CreateObject(this);
            _rules = BaseObjectApi<Rules>.CreateObject(this);
            _qualityProfiles = BaseObjectApi<QualityProfiles>.CreateObject(this);
            _qualityGates = BaseObjectApi<QualityGates>.CreateObject(this);
            _projects = BaseObjectApi<Projects>.CreateObject(this);
            _plugins = BaseObjectApi<Plugins>.CreateObject(this);
            _users = BaseObjectApi<Users>.CreateObject(this);
            _userGroups = BaseObjectApi<UserGroups>.CreateObject(this);
            _permissions = BaseObjectApi<Permissions>.CreateObject(this);
            _metrics = BaseObjectApi<Metrics>.CreateObject(this);
        }

        /// <summary>
        /// Sonar Api client constructor. One instance per Sonar server address.
        /// </summary>
        public SonarApiClient() : this(new Uri(ConfigurationManager.AppSettings["SonarApiUri"]))
        {
        }

        #endregion Constructors

        #region Properties

        public string BaseAddress
        {
            get { return _baseAddress; }
        }

        /// <summary>
        /// Manage the issues
        /// </summary>
        public Issues Issues
        {
            get { return _issues; }
        }

        public Business.System.System System
        {
            get { return _system; }
        }

        /// <summary>
        /// Manage issue filters 
        /// </summary>
        public Filters Filters
        {
            get { return _filters; }
        }

        /// <summary>
        /// Manage programming languages
        /// </summary>
        public Languages Languages
        {
            get { return _languages; }
        }

        /// <summary>
        /// Manage sonar rules
        /// </summary>
        public Rules Rules
        {
            get { return _rules; }
        }

        /// <summary>
        /// Manage quality profiles
        /// </summary>
        public QualityProfiles QualityProfiles
        {
            get { return _qualityProfiles; }
        }

        /// <summary>
        /// Manage quality gates, including conditions and project association
        /// </summary>
        public QualityGates QualityGates
        {
            get { return _qualityGates; }
        }

        /// <summary>
        /// Manage projects
        /// </summary>
        public Projects Projects
        {
            get { return _projects; }
        }

        /// <summary>
        /// Manage the plugins on the server
        /// </summary>
        public Plugins Plugins
        {
            get { return _plugins; }
        }

        /// <summary>
        /// Manage users
        /// </summary>
        public Users Users
        {
            get { return _users; }
        }

        /// <summary>
        /// Manage user groups
        /// </summary>
        public UserGroups UserGroups
        {
            get { return _userGroups; }
        }

        /// <summary>
        /// Manage permissions
        /// </summary>
        public Permissions Permissions
        {
            get { return _permissions; }
        }

        /// <summary>
        /// Manage metrics
        /// </summary>
        public Metrics Metrics
        {
            get { return _metrics; }
        }

        #endregion Properties

        #region Methods

        #region Synchronous methods

        /// <summary>
        /// Generic SonarQube API call for getting a list of objects
        /// </summary>
        /// <typeparam name="T">Typically a class returned by Sonar (cf Sonar classes)</typeparam>
        /// <param name="queryUrl">
        /// A full query URL (should work in a browser), must target Json, must be compatible with
        /// the wanted type T
        /// </param>
        /// <returns>A list of deserialized T from resulting returned by Sonar</returns>
        public static List<T> QueryList<T>(string queryUrl)
        {
            using (WebClient client = GetWebClient())
            {
                string json = null;
                CallWebApi(() => json = client.DownloadString(queryUrl));
                var list = JsonConvert.DeserializeObject<List<T>>(json ?? "[]");
                return list;
            }
        }

        /// <summary>
        /// Generic SonarQube API call for getting a single object
        /// </summary>
        /// <typeparam name="T">The class to materialize from the data returned by SonarQube</typeparam>
        /// <param name="queryUrl">The full SonarQube query url</param>
        /// <returns>An instance of T</returns>
        public static T QueryObject<T>(string queryUrl)
        {
            using (WebClient client = GetWebClient())
            {
                string json = null;
                CallWebApi(() => json = client.DownloadString(queryUrl));
                T obj = JsonConvert.DeserializeObject<T>(json);
                return obj;
            }
        }

        /// <summary>
        /// Method POST data to queryUrl
        /// </summary>
        /// <param name="queryUrl">The full SonarQube query url where data is post</param>
        /// <param name="data">the data to post</param>
        public static void Post(string queryUrl, string data)
        {
            using (WebClient client = GetWebClient())
            {
                CallWebApi(() => client.UploadString(queryUrl, data));
            }
        }

        /// <summary>
        /// Method DELETE data to queryUrl
        /// </summary>
        /// <param name="queryUrl">The full SonarQube query url where data is removed</param>
        /// <param name="data">data to removed</param>
        /// <returns></returns>
        public static bool Delete(string queryUrl, string data)
        {
            using (WebClient client = GetWebClient())
            {
                var result = CallWebApi(() => client.UploadString(queryUrl, "DELETE", data), false);
                return string.IsNullOrEmpty(result);
            }
        }

        /// <summary>
        /// Calls the web API.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="rethrow">if set to <c>true</c> [rethrow].</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        private static string CallWebApi(Action a, bool rethrow = true)
        {
            string result = null;
            try
            {
                a();
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                    result = reader.ReadToEnd();
                    if (rethrow)
                    {
                        throw new WebException(string.Format("Sonar API error: {0}", result), ex);
                    }
                }
                else
                {
                    throw;
                }
            }
            return result;
        }

        #endregion Synchronous methods

        #region Asynchronous methods

        /// <summary>
        /// Method POST data to queryUrl asynchronously
        /// </summary>
        /// <param name="queryUrl">The full SonarQube query url where data is post</param>
        /// <param name="data">the data to post</param>
        public async static Task PostAsync(string queryUrl, string data)
        {
            using (WebClient client = GetWebClient())
            {
                await CallWebApiAsync(() => Task.Factory.StartNew(() => client.UploadString(queryUrl, data)))
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Method DELETE data to queryUrl asynchronously
        /// </summary>
        /// <param name="queryUrl">The full SonarQube query url where data is removed</param>
        /// <param name="data">data to removed</param>
        /// <returns></returns>
        public async static Task<bool> DeleteAsync(string queryUrl, string data)
        {
            using (WebClient client = GetWebClient())
            {
                var result = await CallWebApiAsync(() => Task.Factory.StartNew(() => client.UploadString(queryUrl, "DELETE", data)), false)
                    .ConfigureAwait(false);
                return string.IsNullOrEmpty(result);
            }
        }

        /// <summary>
        /// Generic SonarQube API call for getting a list of objects asynchronously
        /// </summary>
        /// <typeparam name="T">Typically a class returned by Sonar (cf Sonar classes)</typeparam>
        /// <param name="queryUrl">
        /// A full query URL (should work in a browser), must target Json, must be compatible with
        /// the wanted type T
        /// </param>
        /// <returns>A list of deserialized T from resulting returned by Sonar</returns>
        public async static Task<List<T>> QueryListAsync<T>(string queryUrl)
        {
            using (WebClient client = GetWebClient())
            {
                string json = null;
                await CallWebApiAsync(() => Task.Factory.StartNew(() => json = client.DownloadString(queryUrl)))
                    .ConfigureAwait(false);
                var list = JsonConvert.DeserializeObject<List<T>>(json ?? "[]");
                return list;
            }
        }

        /// <summary>
        /// Generic SonarQube API call for getting a single object asynchronously
        /// </summary>
        /// <typeparam name="T">The class to materialize from the data returned by SonarQube</typeparam>
        /// <param name="queryUrl">The full SonarQube query url</param>
        /// <returns>An instance of T</returns>
        public async static Task<T> QueryObjectAsync<T>(string queryUrl)
        {
            using (WebClient client = GetWebClient())
            {
                string json = null;
                await CallWebApiAsync(() => Task.Factory.StartNew(() => json = client.DownloadString(queryUrl)))
                    .ConfigureAwait(false);
                T obj = JsonConvert.DeserializeObject<T>(json);
                return obj;
            }
        }

        /// <summary>
        /// Calls the web API asynchronous.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="rethrow">if set to <c>true</c> [rethrow].</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        private static async Task<string> CallWebApiAsync(Func<Task<string>> a, bool rethrow = true)
        {
            string result = null;
            try
            {
                await a().ConfigureAwait(false);
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                    result = reader.ReadToEnd();
                    if (rethrow)
                    {
                        throw new WebException(string.Format("Sonar API error: {0}", result), ex);
                    }
                }
                else
                {
                    throw;
                }
            }
            return await Task.Factory.StartNew(() => result).ConfigureAwait(false);
        }

        #endregion Asynchronous methods

        /// <summary>
        /// Gets the web client.
        /// </summary>
        /// <param name="timeOut">The time out.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">
        /// SonarApiLogin not found in app.config !
        /// or
        /// SonarApiPassword not found in app.config !
        /// </exception>
        private static WebClient GetWebClient(int timeOut = 0)
        {
            WebClient client = (timeOut == 0) ? new WebClient() : new CustomTimeOutWebClient(timeOut);
            string token = ConfigurationManager.AppSettings["SonarApiToken"];
            if (string.IsNullOrEmpty(token))
            {
                string login = ConfigurationManager.AppSettings["SonarApiLogin"];
                string password = ConfigurationManager.AppSettings["SonarApiPassword"];

                if (String.IsNullOrEmpty(login))
                {
                    throw new ArgumentNullException("SonarApiLogin not found in app.config !");
                }
                if (String.IsNullOrEmpty(password))
                {
                    throw new ArgumentNullException("SonarApiPassword not found in app.config !");
                }

                string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(login + ":" + password));
                client.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;
            }
            else
            {
                string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(token + ":"));
                client.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;
            }
            client.Encoding = Encoding.UTF8; // because of special characters like accents

            return client;
        }

        #endregion Methods
    }
}