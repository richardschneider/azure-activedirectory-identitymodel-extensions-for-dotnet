//-----------------------------------------------------------------------
// Copyright (c) Microsoft Open Technologies, Inc.
// All Rights Reserved
// Apache License 2.0
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-----------------------------------------------------------------------

using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Web;

namespace Microsoft.IdentityModel.Test
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class OpenIdConnectMessageTests
    {
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassSetup( TestContext testContext )
        {
            // Start local STS
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            // Stop local STS
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        [TestProperty("TestCaseID", "CFB7A712-9FA8-4A31-8446-2EA93CECC2AC")]
        [Description("Tests: Constructors")]
        public void OpenIdConnectMessage_Constructors()
        {
            OpenIdConnectMessage openIdConnectMessage = new OpenIdConnectMessage();
            Assert.AreEqual(openIdConnectMessage.IssuerAddress, string.Empty);
            openIdConnectMessage = new OpenIdConnectMessage("http://www.got.jwt.com");
            Assert.AreEqual(openIdConnectMessage.IssuerAddress, "http://www.got.jwt.com");
            ExpectedException expectedException = ExpectedException.ArgumentNullException("issuerAddress");
            try
            {
                openIdConnectMessage = new OpenIdConnectMessage((string)null);
                expectedException.ProcessNoException();
            }
            catch (Exception exception)
            {
                expectedException.ProcessException(exception);
            }
        }

        [TestMethod]
        [TestProperty("TestCaseID", "B644D6D6-26C0-4417-AF9C-F59CFC5E7903")]
        [Description("Tests: Defaults")]
        public void OpenIdConnectMessage_Defaults()
        {
            List<string> errors = new List<string>();

            OpenIdConnectMessage message = new OpenIdConnectMessage();
            
            if (message.AcrValues != null)
                errors.Add("message.ArcValues != null");

            if (message.ClientAssertion != null)
                errors.Add("message.ClientAssertion != null");

            if (message.ClientAssertionType != null)
                errors.Add("message.ClientAssertionType != null");

            if (message.ClaimsLocales != null)
                errors.Add("message.ClaimsLocales != null");

            if (message.ClientId != null)
                errors.Add("message.ClientId != null");

            if (message.ClientSecret != null)
                errors.Add("message.ClientSecret != null");

            if (message.Code != null)
                errors.Add("message.Code != null");

            if (message.Display != null)
                errors.Add("message.Display != null");

            if (message.IdTokenHint != null)
                errors.Add("message.IdTokenHint != null");

            if (message.LoginHint != null)
                errors.Add("message.LoginHint != null");

            if (message.MaxAge != null)
                errors.Add("message.MaxAge != null");

            if (string.IsNullOrWhiteSpace(message.Nonce))
                errors.Add("message.Nonce was null or whitespace.");

            if (message.Prompt != null)
                errors.Add("message.Prompt != null");

            if (message.RedirectUri != null)
                errors.Add("message.RedirectUri != null");

            if (message.ResponseMode != OpenIdConnectMessage.DefaultResponseMode)
                errors.Add(string.Format(CultureInfo.InvariantCulture, "message.ResponseMode: '{0}' != OpenIdConnectMessage.DefaultResponseMode: '{1}'", message.ResponseMode, OpenIdConnectMessage.DefaultResponseMode));

            if (message.ResponseType != OpenIdConnectMessage.DefaultResponseType)
                errors.Add(string.Format(CultureInfo.InvariantCulture, "message.ResponseType: '{0}' != OpenIdConnectMessage.DefaultResponseType: '{1}'", message.ResponseMode, OpenIdConnectMessage.DefaultResponseType));

            if (message.Scope != OpenIdConnectMessage.DefaultScope)
                errors.Add(string.Format(CultureInfo.InvariantCulture, "message.Scope: '{0}' != OpenIdConnectMessage.DefaultScope: '{1}'", message.Scope, OpenIdConnectMessage.DefaultScope));

            if (message.State != null)
                errors.Add("message.State != null");

            if (message.UiLocales != null)
                errors.Add("message.UiLocales != null");

            if (errors.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string error in errors)
                    sb.AppendLine(error);

                Assert.Fail("OpenIdConnectMessage_Defaults *** Test Failures:\n" + sb.ToString());
            }
        }

        [TestMethod]
        [TestProperty("TestCaseID", "E3499C32-5062-4F89-A209-3024613EB73B")]
        [Description("Tests: GetSets")]
        public void OpenIdConnectMessage_GetSets()
        {
            OpenIdConnectMessage message = new OpenIdConnectMessage();
            Type type = typeof(OpenIdConnectMessage);
            PropertyInfo[] properties = type.GetProperties();
            if (properties.Length != 50)
                Assert.Fail("Number of public fields has changed from 50 to: " + properties.Length + ", adjust tests");

            GetSetContext context =
                new GetSetContext
                {
                    PropertyNamesAndSetGetValue = new List<KeyValuePair<string, List<object>>>
                    {
                        new KeyValuePair<string, List<object>>("IssuerAddress", new List<object>{string.Empty, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("AuthorizationEndpoint", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("AccessToken", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("AcrValues", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("ClaimsLocales", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("ClientAssertion", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("ClientAssertionType", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("ClientId", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("ClientSecret", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("Code", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("Display", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("DomainHint", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("Error",  new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("ErrorDescription",  new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("ErrorUri",  new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("ExpiresIn",  new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("GrantType", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("IdToken", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("IdTokenHint", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("IdentityProvider", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("MaxAge", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("Password", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("PostLogoutRedirectUri", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("Prompt", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("RedirectUri", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("RequestUri", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("ResponseMode", new List<object>{OpenIdConnectMessage.DefaultResponseMode, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("ResponseType", new List<object>{OpenIdConnectMessage.DefaultResponseType, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("Resource", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("Scope", new List<object>{OpenIdConnectMessage.DefaultScope, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("SessionState", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("State", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("TargetLinkUri", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("Token", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("TokenEndpoint", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("TokenType", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("UiLocales", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("UserId", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                        new KeyValuePair<string, List<object>>("Username", new List<object>{(string)null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}),
                    },

                    Object = message,
                };

            TestUtilities.GetSet(context);

            if (context.Errors.Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(Environment.NewLine);
                foreach (string str in context.Errors)
                    sb.AppendLine(str);

                Assert.Fail(sb.ToString());
            }
        }

        [TestMethod]
        [TestProperty("TestCaseID", "38024A53-CF6A-48C4-8AF3-E9C97E2B86FC")]
        [Description( "Tests: Publics" )]
        public void OpenIdConnectMessage_Publics()
        {
            string issuerAddress = "http://gotJwt.onmicrosoft.com";
            string redirectUri = "http://gotJwt.onmicrosoft.com/signedIn";
            string resource = "location data";
            string customParameterName = "Custom Parameter Name";
            string customParameterValue = "Custom Parameter Value";

            List<string> errors = new List<string>();

            // Empty string
            OpenIdConnectMessage message = new OpenIdConnectMessage();
            string url = message.BuildRedirectUrl();
            string expected = string.Format(CultureInfo.InvariantCulture, @"?nonce={0}&response_mode=form_post&response_type=code+id_token&scope=openid+profile", message.Nonce);
            Report(errors, url, expected);
            
            // IssuerAddress only
            message = new OpenIdConnectMessage(issuerAddress);
            url = message.BuildRedirectUrl();
            expected = string.Format(CultureInfo.InvariantCulture, @"{0}?nonce={1}&response_mode=form_post&response_type=code+id_token&scope=openid+profile", issuerAddress, message.Nonce);
            Report(errors, url, expected);

            // IssuerAdderss and Redirect_uri
            message.RedirectUri = redirectUri;
            url = message.BuildRedirectUrl();
            expected = string.Format(CultureInfo.InvariantCulture, @"{0}?nonce={1}&response_mode=form_post&response_type=code+id_token&scope=openid+profile&redirect_uri={2}", issuerAddress, message.Nonce, HttpUtility.UrlEncode(redirectUri));
            Report(errors, url, expected);

            // IssuerAdderss empty and Redirect_uri
            message.IssuerAddress = string.Empty;
            url = message.BuildRedirectUrl();
            expected = string.Format(CultureInfo.InvariantCulture, @"?nonce={0}&response_mode=form_post&response_type=code+id_token&scope=openid+profile&redirect_uri={1}", message.Nonce, HttpUtility.UrlEncode(redirectUri));
            Report(errors, url, expected);

            // IssuerAdderss, Redirect_uri, Response
            message = new OpenIdConnectMessage(issuerAddress);
            message.RedirectUri = redirectUri;
            message.Resource = resource;
            url = message.BuildRedirectUrl();
            expected = string.Format(CultureInfo.InvariantCulture, @"{0}?nonce={1}&response_mode=form_post&response_type=code+id_token&scope=openid+profile&redirect_uri={2}&resource={3}", issuerAddress, message.Nonce, HttpUtility.UrlEncode(redirectUri), HttpUtility.UrlEncode(resource));
            Report(errors, url, expected);

            // IssuerAdderss, Redirect_uri, Response, customParam
            message = new OpenIdConnectMessage(issuerAddress);
            message.Parameters.Add(customParameterName, customParameterValue);
            message.RedirectUri = redirectUri;
            message.Resource = resource;
            url = message.BuildRedirectUrl();
            expected = string.Format(CultureInfo.InvariantCulture, @"{0}?nonce={1}&response_mode=form_post&response_type=code+id_token&scope=openid+profile&{2}={3}&redirect_uri={4}&resource={5}", issuerAddress, message.Nonce, HttpUtility.UrlEncode(customParameterName), HttpUtility.UrlEncode(customParameterValue), HttpUtility.UrlEncode(redirectUri), HttpUtility.UrlEncode(resource));
            Report(errors, url, expected);

            if (errors.Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(Environment.NewLine);
                foreach (string str in errors)
                    sb.AppendLine(str);

                Assert.Fail(sb.ToString());
            }
        }

        [TestMethod]
        [TestProperty("TestCaseID", "TBD")]
        [Description( "Tests: NULL form parameters" )]
        public void OpenIdConnectMessage_NullFormParameters()
        {
            List<KeyValuePair<string, string[]>> formData = new List<KeyValuePair<string, string[]>>();
            formData.Add(new KeyValuePair<string, string[]>("key", new string[] { "data" }));
            formData.Add(new KeyValuePair<string, string[]>("nullData", new string[] { null }));
            formData.Add(new KeyValuePair<string, string[]>("emptyData", new string[] { string.Empty }));
            formData.Add(new KeyValuePair<string, string[]>(null, new string[] { null }));
            formData.Add(new KeyValuePair<string, string[]>(null, null));
            OpenIdConnectMessage msg = new OpenIdConnectMessage(formData);
            Assert.IsNotNull(msg);
        }

        private void Report(List<string> errors, string url, string expected)
        {
            if (!string.Equals(url, expected, StringComparison.Ordinal))
                errors.Add("IssuerAdderss, Redirect_uri, Response, customParam: message.BuildRedirectUrl() != expected: " + Environment.NewLine + url + Environment.NewLine + expected);
        }
    }
}

