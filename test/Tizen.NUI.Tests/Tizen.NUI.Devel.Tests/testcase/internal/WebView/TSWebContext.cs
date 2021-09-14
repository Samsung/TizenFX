using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebContext")]
    public class InternalWebContextTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        private static string[] runtimeArgs = { "Tizen.NUI.Devel.Tests", "--enable-dali-window", "--enable-spatial-navigation" };
        private const string USER_AGENT = "Mozilla/5.0 (SMART-TV; Linux; Tizen 6.0) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/4.0 Chrome/76.0.3809.146 TV Safari/537.36";

        private void OriginListAcquiredCallback (WebSecurityOriginList list) { }
        private void OnStorageUsageAcquired(ulong usage) { }
        private void PasswordAcquiredCallback (WebPasswordDataList list) { }
        private void DownloadCallback (string url) { }
        private void UsageAcquiredCallback (ulong usage) { }
        private bool MimeWrittenCallback(string url, string currentMime, string newMime) 
        {
            return true;
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext ProxyUrl.")]
        [Property("SPEC", "Tizen.NUI.WebContext.ProxyUrl A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextProxyUrl()
        {
            tlog.Debug(tag, $"WebContextProxyUrl START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;
            tlog.Debug(tag, "ProxyUrl : " + context.ProxyUrl);

            context.ProxyUrl = "http://www.baidu.com";
            tlog.Debug(tag, "ProxyUrl : " + context.ProxyUrl);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextProxyUrl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext CertificateFilePath.")]
        [Property("SPEC", "Tizen.NUI.WebContext.CertificateFilePath A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextCertificateFilePath()
        {
            tlog.Debug(tag, $"WebContextCertificateFilePath START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;
            tlog.Debug(tag, "CertificateFilePath : " + context.CertificateFilePath);

            context.CertificateFilePath = url;
            tlog.Debug(tag, "CertificateFilePath : " + context.CertificateFilePath);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextCertificateFilePath END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext CacheEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebContext.CacheEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextCacheEnabled()
        {
            tlog.Debug(tag, $"WebContextCacheEnabled START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;
            tlog.Debug(tag, "CacheEnabled : " + context.CacheEnabled);

            context.CacheEnabled = true;
            tlog.Debug(tag, "CacheEnabled : " + context.CacheEnabled);

            context.CacheEnabled = false;
            tlog.Debug(tag, "CacheEnabled : " + context.CacheEnabled);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextCertificateFilePath END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext AppId.")]
        [Property("SPEC", "Tizen.NUI.WebContext.AppId A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextAppId()
        {
            tlog.Debug(tag, $"WebContextAppId START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;
            tlog.Debug(tag, "AppId : " + context.AppId);

            context.AppId = "WebContextAppId";
            tlog.Debug(tag, "AppId : " + context.AppId);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextAppId END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext AppVersion.")]
        [Property("SPEC", "Tizen.NUI.WebContext.AppVersion A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextAppVersion()
        {
            tlog.Debug(tag, $"WebContextAppVersion START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;
            tlog.Debug(tag, "AppVersion : " + context.AppVersion);

            context.AppVersion = "1.0";
            tlog.Debug(tag, "AppVersion : " + context.AppVersion);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextAppVersion END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext AppType.")]
        [Property("SPEC", "Tizen.NUI.WebContext.AppType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextAppType()
        {
            tlog.Debug(tag, $"WebContextAppType START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;
            tlog.Debug(tag, "AppType : " + context.AppType);

            context.AppType = WebContext.ApplicationType.WebBrowser;
            tlog.Debug(tag, "AppType : " + context.AppType);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextAppType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext TimeOffset.")]
        [Property("SPEC", "Tizen.NUI.WebContext.TimeOffset A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextTimeOffset()
        {
            tlog.Debug(tag, $"WebContextTimeOffset START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;
            tlog.Debug(tag, "TimeOffset : " + context.TimeOffset);

            context.TimeOffset = 0.3f;
            tlog.Debug(tag, "TimeOffset : " + context.TimeOffset);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextAppType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext DefaultZoomFactor.")]
        [Property("SPEC", "Tizen.NUI.WebContext.DefaultZoomFactor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextDefaultZoomFactor()
        {
            tlog.Debug(tag, $"WebContextDefaultZoomFactor START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;
            tlog.Debug(tag, "DefaultZoomFactor : " + context.DefaultZoomFactor);

            context.DefaultZoomFactor = 0.3f;
            tlog.Debug(tag, "DefaultZoomFactor : " + context.DefaultZoomFactor);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextDefaultZoomFactor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext ContextProxy.")]
        [Property("SPEC", "Tizen.NUI.WebContext.ContextProxy A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextContextProxy()
        {
            tlog.Debug(tag, $"WebContextContextProxy START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;
            tlog.Debug(tag, "ContextProxy : " + context.ContextProxy);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextContextProxy END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext ProxyBypassRule.")]
        [Property("SPEC", "Tizen.NUI.WebContext.ProxyBypassRule A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextProxyBypassRule()
        {
            tlog.Debug(tag, $"WebContextProxyBypassRule START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;
            tlog.Debug(tag, "ProxyBypassRule : " + context.ProxyBypassRule);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextProxyBypassRule END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext SetDefaultProxyAuth.")]
        [Property("SPEC", "Tizen.NUI.WebContext.SetDefaultProxyAuth M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextSetDefaultProxyAuth()
        {
            tlog.Debug(tag, $"WebContextSetDefaultProxyAuth START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;

            try
            {
                context.SetDefaultProxyAuth("tizen", "samsung");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextSetDefaultProxyAuth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext DeleteAllWebDatabase.")]
        [Property("SPEC", "Tizen.NUI.WebContext.DeleteAllWebDatabase M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextDeleteAllWebDatabase()
        {
            tlog.Debug(tag, $"WebContextDeleteAllWebDatabase START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;

            try
            {
                context.DeleteAllWebDatabase();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextDeleteAllWebDatabase END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext GetWebDatabaseOrigins.")]
        [Property("SPEC", "Tizen.NUI.WebContext.GetWebDatabaseOrigins M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextGetWebDatabaseOrigins()
        {
            tlog.Debug(tag, $"WebContextGetWebDatabaseOrigins START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;

            try
            {
                context.GetWebDatabaseOrigins(OriginListAcquiredCallback);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextGetWebDatabaseOrigins END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext DeleteWebDatabase.")]
        [Property("SPEC", "Tizen.NUI.WebContext.DeleteWebDatabase M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextDeleteWebDatabase()
        {
            tlog.Debug(tag, $"WebContextDeleteWebDatabase START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;

            try
            {
                using (WebSecurityOrigin origin = new WebSecurityOrigin(testingTarget.SwigCPtr.Handle, false))
                {
                    context.DeleteWebDatabase(origin);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextDeleteWebDatabase END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext GetWebStorageOrigins.")]
        [Property("SPEC", "Tizen.NUI.WebContext.GetWebStorageUsageForOrigin M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebContextGetWebStorageUsageForOrigin()
        {
            tlog.Debug(tag, $"WebContextGetWebStorageUsageForOrigin START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView(runtimeArgs)
            {
                Size = new Size(500, 200),
                UserAgent = USER_AGENT
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return Tizen.NUI.BaseComponents.WebView instance.");

            testingTarget.LoadUrl("https://www.youtube.com");
            await Task.Delay(60000);

            try
            {
                var result = testingTarget.Context.GetWebStorageOrigins(OnSecurityOriginListAcquired);
                tlog.Error(tag, "result : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
            tlog.Debug(tag, $"GetWebStorageOrigins END (OK)");
        }

        private void OnSecurityOriginListAcquired(WebSecurityOriginList list)
        {   
            WebSecurityOrigin origin = list.GetItemAtIndex(0);
            tlog.Debug(tag, "security origin, Host : " + origin.Host);
            tlog.Debug(tag, "security origin, Protocol : " + origin.Protocol);
        }

        [Test]
        [Category("P1")]
        [Description("WebContext DeleteAllWebStorage.")]
        [Property("SPEC", "Tizen.NUI.WebContext.DeleteAllWebStorage M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextDeleteAllWebStorage()
        {
            tlog.Debug(tag, $"WebContextDeleteAllWebStorage START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;

            try
            {
                context.DeleteAllWebStorage();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextDeleteAllWebStorage END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext DeleteLocalFileSystem.")]
        [Property("SPEC", "Tizen.NUI.WebContext.DeleteLocalFileSystem M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextDeleteLocalFileSystem()
        {
            tlog.Debug(tag, $"WebContextDeleteLocalFileSystem START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;

            try
            {
                context.DeleteLocalFileSystem();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextDeleteLocalFileSystem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext GetFormPasswordList.")]
        [Property("SPEC", "Tizen.NUI.WebContext.GetFormPasswordList M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextGetFormPasswordList()
        {
            tlog.Debug(tag, $"WebContextGetFormPasswordList START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;

            try
            {
                context.GetFormPasswordList(PasswordAcquiredCallback);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextGetFormPasswordList END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext RegisterDownloadStartedCallback.")]
        [Property("SPEC", "Tizen.NUI.WebContext.RegisterDownloadStartedCallback M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextRegisterDownloadStartedCallback()
        {
            tlog.Debug(tag, $"WebContextRegisterDownloadStartedCallback START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;

            try
            {
                context.RegisterDownloadStartedCallback(DownloadCallback);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextRegisterDownloadStartedCallback END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext RegisterMimeOverriddenCallback.")]
        [Property("SPEC", "Tizen.NUI.WebContext.RegisterMimeOverriddenCallback M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextRegisterMimeOverriddenCallback()
        {
            tlog.Debug(tag, $"WebContextRegisterMimeOverriddenCallback START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;

            try
            {
                context.RegisterMimeOverriddenCallback(MimeWrittenCallback);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextRegisterMimeOverriddenCallback END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext SetTimeZoneOffset.")]
        [Property("SPEC", "Tizen.NUI.WebContext.SetTimeZoneOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextSetTimeZoneOffset()
        {
            tlog.Debug(tag, $"WebContextSetTimeZoneOffset START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;

            try
            {
                context.SetTimeZoneOffset(0.3f, 1.0f);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextSetTimeZoneOffset END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext SetContextTimeZoneOffset.")]
        [Property("SPEC", "Tizen.NUI.WebContext.SetContextTimeZoneOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextSetContextTimeZoneOffset()
        {
            tlog.Debug(tag, $"WebContextSetContextTimeZoneOffset START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;

            try
            {
                context.SetContextTimeZoneOffset(0.3f, 1.0f);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextSetContextTimeZoneOffset END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext DeleteAllApplicationCache.")]
        [Property("SPEC", "Tizen.NUI.WebContext.DeleteAllApplicationCache M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextDeleteAllApplicationCache()
        {
            tlog.Debug(tag, $"WebContextDeleteAllApplicationCache START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;

            try
            {
                context.DeleteAllApplicationCache();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextDeleteAllApplicationCache END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext DeleteAllWebIndexedDatabase.")]
        [Property("SPEC", "Tizen.NUI.WebContext.DeleteAllWebIndexedDatabase M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextDeleteAllWebIndexedDatabase()
        {
            tlog.Debug(tag, $"WebContextDeleteAllWebIndexedDatabase START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;

            try
            {
                context.DeleteAllWebIndexedDatabase();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextDeleteAllWebIndexedDatabase END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext DeleteAllFormPasswordData.")]
        [Property("SPEC", "Tizen.NUI.WebContext.DeleteAllFormPasswordData M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextDeleteAllFormPasswordData()
        {
            tlog.Debug(tag, $"WebContextDeleteAllFormPasswordData START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var context = testingTarget.Context;

            try
            {
                context.DeleteAllFormPasswordData();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextDeleteAllFormPasswordData END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext DeleteAllFormCandidateData.")]
        [Property("SPEC", "Tizen.NUI.WebContext.DeleteAllFormCandidateData M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextDeleteAllFormCandidateData()
        {
            tlog.Debug(tag, $"WebContextDeleteAllFormCandidateData START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.LoadUrl("http://www.baidu.com");
            var context = testingTarget.Context;

            try
            {
                context.DeleteAllFormCandidateData();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextDeleteAllFormCandidateData END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext FreeUnusedMemory.")]
        [Property("SPEC", "Tizen.NUI.WebContext.FreeUnusedMemory M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextFreeUnusedMemory()
        {
            tlog.Debug(tag, $"WebContextFreeUnusedMemory START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.LoadUrl("http://www.baidu.com");
            var context = testingTarget.Context;

            try
            {
                context.FreeUnusedMemory();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            context.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextFreeUnusedMemory END (OK)");
        }
    }
}
